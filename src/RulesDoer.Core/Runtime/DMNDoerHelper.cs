using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime {
    public static class DMNDoerHelper {

        public static Variable EvaluateDecisionByName (VariableContext runtimeContext, string decisionName) {

            if (runtimeContext == null || runtimeContext.DecisionMetaByName == null) {
                return null;
            }

            runtimeContext.DecisionMetaByName.TryGetValue (decisionName, out var decision);

            if (decision == null) {
                return null;
            }

            //cannot run a decision serivce input without an input override value
            if (decision.Id != null) {
                runtimeContext.HrefInputDecisionToDecisionServices.TryGetValue (decision.Id, out var decisionServices);
                runtimeContext.InputNameDict.TryGetValue ("decisionName", out var decisionInput);
                if (decisionServices != null && decisionInput == null) {
                    throw new DMNException ($"Decision :{decisionName} is part of a decision service input and is missing input data");
                }
            }

            return decision.Expression
            switch {
                TLiteralExpression litExpr => EvalLiteralExpression (litExpr.Text, runtimeContext),
                    TDecisionTable decisionTable => EvalDecisionTable (decisionTable, runtimeContext),
                    TContext contextDecision => EvalContext (contextDecision, runtimeContext),
                    TRelation relation => EvalRelation (relation, runtimeContext),
                    TInvocation invocation => EvalInvocation (invocation, runtimeContext),
                    _ =>
                    throw new DMNException ($"Decision expression {decision.Expression.Id} is not supported yet"),
            };
        }
        public static Variable EvalDecisionTable (TDecisionTable decisionTable, VariableContext runtimeContext) {

            var matchedList = new List<Dictionary<string, Variable>> ();
            Evaluation evalExpression = new Evaluation ();
            if (decisionTable.HitPolicy == THitPolicy.PRIORITY || decisionTable.HitPolicy == THitPolicy.OUTPUT_ORDER) {
                var outcnt = decisionTable.Output.Count;
                for (int i = 0; i < decisionTable.Output.Count; i++) {
                    if (decisionTable.Output[i].OutputValues != null) {
                        var itemlist = evalExpression.EvaluateSimpleExpressionsBase (decisionTable.Output[i].OutputValues.Text, runtimeContext);
                        if (itemlist.ValueType != DataTypeEnum.List) {
                            outcnt--;
                            continue;
                        }
                        var listCnt = itemlist.ListVal.Count;
                        decisionTable.Output[i].PriorityList.Clear ();
                        for (int x = 0; x < itemlist.ListVal.Count; x++) {
                            decisionTable.Output[i].PriorityList.Add (itemlist.ListVal[x], outcnt * listCnt);
                            listCnt--;

                        }
                        outcnt--;
                    }
                }

            }

            foreach (var input in decisionTable.Input) {
                var inputExprText = input.InputExpression.Text;
                if (!string.IsNullOrEmpty (inputExprText) && !runtimeContext.InputNameDict.ContainsKey (inputExprText)) {
                    var inputVal = EvalLiteralExpression (inputExprText, runtimeContext);
                    if (inputVal != null && inputVal.ValueType != DataTypeEnum.Null) {
                        runtimeContext.AddToInputDict (inputExprText, inputVal);
                    }
                }
            }

            foreach (var rule in decisionTable.Rule) {
                var matched = false;
                for (int i = 0; i < rule.InputEntry.Count; i++) {
                    matched = evalExpression.EvaluateUnaryTestsBase (rule.InputEntry[i].Text, runtimeContext, decisionTable.Input[i].InputExpression.Text);
                    if (!matched) {
                        break;
                    }
                }

                if (matched) {
                    var outputDict = new Dictionary<string, Variable> ();
                    int prioritySum = 0;
                    for (int i = 0; i < decisionTable.Output.Count; i++) {
                        var outName = decisionTable.Output[i].Name ?? i.ToString ();
                        var outVar = evalExpression.EvaluateExpressionsBase (rule.OutputEntry[i].Text, runtimeContext);
                        outputDict.Add (outName, outVar);
                        if (decisionTable.HitPolicy == THitPolicy.PRIORITY || decisionTable.HitPolicy == THitPolicy.OUTPUT_ORDER) {
                            if (decisionTable.Output[i].PriorityList.Any ()) {
                                decisionTable.Output[i].PriorityList.TryGetValue (outVar, out var priorityNum);
                                prioritySum += priorityNum;
                            }
                        }
                    }
                    if (decisionTable.HitPolicy == THitPolicy.PRIORITY || decisionTable.HitPolicy == THitPolicy.OUTPUT_ORDER) {
                        outputDict.Add ("__p__", prioritySum);
                    }

                    matchedList.Add (outputDict);

                }

            }

            if (matchedList.Any ()) {
                var dtr = new DecisionTableResult {
                    MatchedList = matchedList,
                    OutputResult = HitPolicyHelper.Output (decisionTable.HitPolicy, matchedList, decisionTable.Aggregation)
                };

                //TODO: Output based on the variable output type reference in decision table meta

                if (decisionTable.HitPolicy == THitPolicy.COLLECT && decisionTable.Aggregation == TBuiltinAggregator.NONE) {
                    if (dtr.OutputResult[0].Keys.Count == 1) {
                        var outL = new List<Variable> ();
                        foreach (var item in dtr.OutputResult) {
                            outL.Add (item.Values.Single ());
                        }
                        return outL;
                    }
                }

                if (dtr.OutputResult.Count == 1 && dtr.OutputResult[0].Count == 1) {
                    foreach (var item in dtr.OutputResult[0]) {
                        return item.Value;
                    }

                }

                return dtr;
            }

            // No rules matched — return the default output entry value if defined
            if (decisionTable.Output.Count == 1 && decisionTable.Output[0].DefaultOutputEntry?.Text != null) {
                return EvalLiteralExpression (decisionTable.Output[0].DefaultOutputEntry.Text, runtimeContext);
            }

            return null;
        }

        public static Variable EvalLiteralExpression (string litExpression, VariableContext runtimeContext) {

            Evaluation evalExpression = new Evaluation ();

            return evalExpression.EvaluateExpressionsBase (litExpression, runtimeContext);

        }

        public static Variable EvalContext (TContext context, VariableContext runtimeContext) {
            var stack = new Stack < (TContext, ContextInputs, ContextInputs, string, int) > ();

            //load context entries
            var cxtCnt = 0;
            var ctxt = new ContextInputs (cxtCnt.ToString ());

            stack.Push ((context, ctxt, null, null, 0));

            Variable outVar = null;
            Variable exitVar = null;

            while (stack.Count > 0) {
                var contextE = stack.Pop ();

                var curTCntxt = contextE.Item1;
                var curCntxt = contextE.Item2;
                var parentCntxt = contextE.Item3;
                var currName = contextE.Item4;
                var currPos = contextE.Item5;
                var currMCnt = contextE.Item1.ContextEntry.Count - 1;

                var currContextEntry = curTCntxt.ContextEntry[currPos];

                currPos++;
                if (currPos <= currMCnt) {
                    stack.Push ((curTCntxt, curCntxt, parentCntxt, currName, currPos));
                }

                //var currCntx = contextE.Item2

                switch (currContextEntry.Expression) {
                    case TLiteralExpression litExpr:
                        outVar = EvalLiteralExpression (litExpr.Text, runtimeContext);
                        break;

                    case TDecisionTable decisionTable:
                        outVar = EvalDecisionTable (decisionTable, runtimeContext);
                        break;

                    case TFunctionDefinition functionDefinition:
                        outVar = EvalUserDefinedFunction (functionDefinition);
                        break;

                    case TInvocation invocation:
                        outVar = EvalInvocation (invocation, runtimeContext);
                        break;

                    case TContext contextType:
                        cxtCnt++;
                        var chldCtxt = new ContextInputs (cxtCnt.ToString ());

                        curCntxt.Add (currContextEntry.Variable.Name, chldCtxt);

                        runtimeContext.AddToInputDict (currContextEntry.Variable.Name, chldCtxt);

                        stack.Push ((contextType, chldCtxt, curCntxt, currContextEntry.Variable.Name, 0));

                        break;

                    default:
                        throw new DMNException ($"Expression {currContextEntry.Expression.GetType()} is not supported yet");
                }

                if (currContextEntry.Expression is TContext) {
                    continue;
                }

                if (currContextEntry.Variable == null) {
                    if (parentCntxt != null) {
                        parentCntxt.ContextDict[currName] = outVar;
                        runtimeContext.AddToInputDict (currName, outVar);
                    } else {
                        exitVar = outVar;
                    }

                    continue;
                }

                curCntxt.Add (currContextEntry.Variable.Name, outVar);

                runtimeContext.AddToInputDict (currContextEntry.Variable.Name, outVar);

            }

            if (exitVar != null) {
                return exitVar;
            }

            return ctxt;

        }

        public static Variable EvalRelation (TRelation relation, VariableContext runtimeContext) {
            var columnNames = new List<string> ();

            foreach (var item in relation.Column) {
                columnNames.Add (item.Name);
            }

            var listRelations = new List<Variable> ();
            foreach (var item in relation.Row) {
                var contextout = new ContextInputs ();
                for (int i = 0; i < item.Expression.Count; i++) {
                    switch (item.Expression[i]) {
                        case TLiteralExpression litExpr:
                            contextout.Add (columnNames[i], EvalLiteralExpression (litExpr.Text, runtimeContext));
                            break;

                        default:
                            throw new DMNException ($"Expression {item.Expression[i].GetType()} is not supported yet");
                    }
                }
                listRelations.Add (contextout);
            }

            return new Variable (listRelations);

        }

        public static Variable EvalDecisionService (TDecisionService decisionService, VariableContext runtimeContext, List<Variable> inputParams) {

            var decisionServiceContext = VariableContextHelper.MakeACopy (runtimeContext);

            //run input decisions
            for (int i = 0; i < decisionService.InputDecision.Count; i++) {
                var decId = decisionService.InputDecision[i].Href.TrimStart ('#');
                decisionServiceContext.DecisionMetaById.TryGetValue (decId, out var decision);
                if (inputParams != null && inputParams.Any ()) {
                    decisionServiceContext.InputNameDict.Add (decision.Name, inputParams[i]);
                }
                var decisionRslt = EvaluateDecisionByName (decisionServiceContext, decision.Name);
                decisionServiceContext.InputNameDict.Add (decision.Name, decisionRslt);
            }

            var outContext = new ContextInputs ();

            //run output decisions - return as context outputs
            foreach (var item in decisionService.OutputDecision) {
                var decId = item.Href.TrimStart ('#');
                decisionServiceContext.DecisionMetaById.TryGetValue (decId, out var decision);
                var decisionRslt = EvaluateDecisionByName (decisionServiceContext, decision.Name);

                outContext.Add (decision.Name, decisionRslt);
            }

            return outContext;

        }

        public static Variable EvalBkm (TBusinessKnowledgeModel bkmModel, VariableContext runtimeContext, List<Variable> inputParamVars) {

            //TODO: needs to handle named parameters
            var bkmContext = VariableContextHelper.MakeACopy (runtimeContext);
            if (bkmModel.EncapsulatedLogic.FormalParameterSpecified) {

                var inputBkmDict = new Dictionary<string, Variable> ();
                for (int i = 0; i < bkmModel.EncapsulatedLogic.FormalParameter.Count; i++) {
                    inputBkmDict.Add (bkmModel.EncapsulatedLogic.FormalParameter[i].Name, inputParamVars[i]);
                }
                SynthesizePrefixContexts (inputBkmDict);
                bkmContext.InputNameDict = inputBkmDict;
            }

            return bkmModel.EncapsulatedLogic.Expression
            switch {
                TLiteralExpression litExpr => EvalLiteralExpression (litExpr.Text, bkmContext),
                    TFunctionDefinition functionDefinition => EvalUserDefinedFunction (functionDefinition),
                    TDecisionTable decisionTable => EvalDecisionTable (decisionTable, bkmContext),
                    TContext contextDecision => EvalContext (contextDecision, bkmContext),
                    TRelation relation => EvalRelation (relation, bkmContext),
                    _ =>
                    throw new DMNException ($"Expression {bkmModel.EncapsulatedLogic.Expression.GetType()} is not supported yet"),
            };
        }

        public static Variable EvalInvocation (TInvocation invocation, VariableContext runtimeContext) {
            if (!(invocation.Expression is TLiteralExpression litExpr)) {
                throw new DMNException ("Invocation callee must be a literal expression containing the BKM name");
            }

            var bkmName = litExpr.Text.Trim ();
            if (!VariableContextHelper.RetrieveBkm (bkmName, runtimeContext, out var bkmMeta)) {
                throw new DMNException ($"BKM '{bkmName}' not found in context");
            }

            var bindingsByParamName = new Dictionary<string, Variable> ();
            foreach (var binding in invocation.Binding) {
                var val = binding.Expression switch {
                    TLiteralExpression le => EvalLiteralExpression (le.Text, runtimeContext),
                    TContext ctx => EvalContext (ctx, runtimeContext),
                    TDecisionTable dt => EvalDecisionTable (dt, runtimeContext),
                    _ => throw new DMNException ($"Binding expression type {binding.Expression?.GetType ()} is not supported")
                };
                bindingsByParamName[binding.Parameter.Name] = val;
            }

            var paramVars = new List<Variable> ();
            foreach (var formalParam in bkmMeta.BKMModel.EncapsulatedLogic.FormalParameter) {
                bindingsByParamName.TryGetValue (formalParam.Name, out var paramVal);
                paramVars.Add (paramVal ?? new Variable ());
            }

            return EvalBkm (bkmMeta.BKMModel, runtimeContext, paramVars);
        }

        public static Variable EvalUserDefinedFunction (TFunctionDefinition funcDef) {

            IExpression expr;
            if (funcDef.Expression != null && funcDef.Expression is TLiteralExpression outExpr) {
                var eval = new Evaluation ();
                expr = eval.ReturnExpressionsBase (outExpr.Text);
            } else {
                throw new DMNException ("Expected a literal expression as the function body");
            }

            var paramList = new List<Variable> ();
            foreach (var item in funcDef.FormalParameter) {
                paramList.Add (new Variable (item.Name, item.TypeRef));
            }

            switch (funcDef.Kind) {
                case TFunctionKind.FEEL:
                    break;

                default:
                    throw new DMNException ($"Only FEEL expresssion function definitions are supported");
            }

            return new UserFunction (paramList, expr, false);
        }

        // When BKM formal parameters use dotted names (e.g. "Person.Gender"), build
        // a synthesized Context entry for the prefix ("Person") so that FEEL path
        // expressions like Person.Gender resolve correctly inside the BKM body.
        private static void SynthesizePrefixContexts (Dictionary<string, Variable> dict) {
            var prefixBuilders = new Dictionary<string, ContextInputs> ();
            foreach (var kv in dict) {
                var dotIdx = kv.Key.IndexOf ('.');
                if (dotIdx < 0) continue;
                var prefix = kv.Key.Substring (0, dotIdx);
                var field = kv.Key.Substring (dotIdx + 1);
                if (!prefixBuilders.TryGetValue (prefix, out var ctx)) {
                    ctx = new ContextInputs (prefix);
                    prefixBuilders[prefix] = ctx;
                }
                ctx.Add (field, kv.Value);
            }
            foreach (var kv in prefixBuilders) {
                dict[kv.Key] = kv.Value;
            }
        }

    }

}