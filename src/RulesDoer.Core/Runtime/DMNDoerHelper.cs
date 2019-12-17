using System;
using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

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

            switch (decision.Expression) {
                case TLiteralExpression litExpr:
                    return DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext);

                case TDecisionTable decisionTable:
                    return DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext);

                case TContext contextDecision:
                    return DMNDoerHelper.EvalContext (contextDecision, runtimeContext);

                case TRelation relation:
                    return DMNDoerHelper.EvalRelation (relation, runtimeContext);

                default:
                    throw new DMNException ($"Decision expression {decision.Expression.Id} is not supported yet");
            }

        }
        public static Variable EvalDecisionTable (TDecisionTable decisionTable, VariableContext runtimeContext) {
            var outputList = new List<Variable> ();
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

            foreach (var rule in decisionTable.Rule) {
                var matched = false;
                for (int i = 0; i < rule.InputEntry.Count; i++) {
                    //TODO: the input clause for input variable name is literal epression which need to run through feel epresion evaluater
                    matched = evalExpression.EvaluateUnaryTestsBase (rule.InputEntry[i].Text, runtimeContext, decisionTable.Input[i].InputExpression.Text);
                    if (!matched) {
                        break;
                    }
                }

                if (matched) {
                    var outputDict = new Dictionary<string, Variable> ();
                    int prioritySum = 0;
                    for (int i = 0; i < decisionTable.Output.Count; i++) {
                        var outName = (decisionTable.Output[i].Name != null) ? decisionTable.Output[i].Name : i.ToString ();
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
                var dtr = new DecisionTableResult ();
                dtr.MatchedList = matchedList;
                dtr.OutputResult = HitPolicyHelper.Output (decisionTable.HitPolicy, matchedList, decisionTable.Aggregation);

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

            return null;
        }

        public static Variable EvalLiteralExpression (string litExpression, VariableContext runtimeContext) {

            Evaluation evalExpression = new Evaluation ();

            return evalExpression.EvaluateExpressionsBase (litExpression, runtimeContext);

        }

        // public Control FindControlSansRecursion (Control root, string id) {
        //     //seed it.
        //     Stack<Control> stack = new Stack<Control> ();
        //     stack.Push (root);

        //     while (stack.Count > 0) {
        //         Control current = stack.Pop ();
        //         if (current.ID == id)
        //             return current;

        //         foreach (Control control in current.Controls) {
        //             stack.Push (control);
        //         }
        //     }

        //     //didn’t find it.
        //     return null;
        // }

        // public static Variable EvalContextDecision (TContext decisionContext, VariableContext runtimeContext) {
        //     var stack = new Stack < (TContext, TContextEntry) > ();
        //     stack.Push ((decisionContext, null));

        //     var parentContext = new ContextInputs ();

        //     while (stack.Count > 0) {
        //         var currContext = stack.Pop ();

        //         if (currContext.Item2 != null) {

        //         }

        //         var contextout = new ContextInputs ();

        //         foreach (var item in currContext.Item1.ContextEntry) {

        //             Variable outVar;
        //             switch (item.Expression) {
        //                 case TLiteralExpression litExpr:
        //                     outVar = DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext);
        //                     break;

        //                 case TDecisionTable decisionTable:
        //                     outVar = DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext);
        //                     break;

        //                 case TContext contextType:
        //                     stack.Push ((contextType, item));
        //                     outVar = null;
        //                     break;

        //                 default:
        //                     throw new DMNException ($"Expression {item.Expression.GetType()} is not supported yet");
        //             }

        //             if (outVar != null && item.Variable != null) {
        //                 contextout.Add (item.Variable.Name, outVar);
        //                 runtimeContext.AddToInputDict (item.Variable.Name, outVar);
        //             }

        //         }

        //     }
        // }

        // public static Variable EvalContextDecision (TContext decisionContext, VariableContext runtimeContext) {
        //     var contextout = new ContextInputs ();

        //     //missing information item - variable.name is a context result - returns a variable

        //     foreach (var item in decisionContext.ContextEntry) {
        //         Variable outVar;
        //         switch (item.Expression) {
        //             case TLiteralExpression litExpr:
        //                 outVar = DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext);
        //                 break;

        //             case TDecisionTable decisionTable:
        //                 outVar = DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext);
        //                 break;

        //             case TContext contextType:
        //                 outVar = DMNDoerHelper.EvalContextDecision (contextType, runtimeContext);
        //                 if (outVar.ValueType != DataTypeEnum.Context)
        //                 {
        //                     return outVar;
        //                 }
        //                 if (outVar.ValueType == DataTypeEnum.Context && item.Variable == null)
        //                 {
        //                     return outVar;
        //                 }
        //                 break;

        //             default:
        //                 throw new DMNException ($"Expression {item.Expression.GetType()} is not supported yet");
        //         }

        //         if (item.Variable == null) {
        //             return outVar;
        //         }

        //         contextout.Add (item.Variable.Name, outVar);
        //         runtimeContext.AddToInputDict (item.Variable.Name, outVar);

        //     }

        //     return contextout;
        // }

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
                        outVar = DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext);
                        break;

                    case TDecisionTable decisionTable:
                        outVar = DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext);
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
                            contextout.Add (columnNames[i], DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext));
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
                bkmContext.InputNameDict = inputBkmDict;
            }

            switch (bkmModel.EncapsulatedLogic.Expression) {
                case TLiteralExpression litExpr:
                    return DMNDoerHelper.EvalLiteralExpression (litExpr.Text, bkmContext);

                case TDecisionTable decisionTable:
                    return DMNDoerHelper.EvalDecisionTable (decisionTable, bkmContext);

                case TContext contextDecision:
                    return DMNDoerHelper.EvalContext (contextDecision, bkmContext);

                case TRelation relation:
                    return DMNDoerHelper.EvalRelation (relation, bkmContext);

                default:
                    throw new DMNException ($"Expression {bkmModel.EncapsulatedLogic.Expression.GetType()} is not supported yet");
            }

        }

    }

}