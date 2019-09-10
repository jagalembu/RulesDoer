using System.Collections.Generic;
using System.Linq;
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

            switch (decision.Expression) {
                case TLiteralExpression litExpr:
                    return DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext);

                case TDecisionTable decisionTable:
                    return DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext);

                case TContext contextDecision:
                    return DMNDoerHelper.EvalContextDecision (contextDecision, runtimeContext);

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

        public static Variable EvalContextDecision (TContext decisionContext, VariableContext runtimeContext) {
            var contextout = new ContextInputs ();
            Evaluation evalExpression = new Evaluation ();

            foreach (var item in decisionContext.ContextEntry) {
                switch (item.Expression) {
                    case TLiteralExpression litExpr:
                        contextout.Add (item.Variable.Name, DMNDoerHelper.EvalLiteralExpression (litExpr.Text, runtimeContext));
                        break;

                    case TDecisionTable decisionTable:
                        contextout.Add (item.Variable.Name, DMNDoerHelper.EvalDecisionTable (decisionTable, runtimeContext));
                        break;

                    default:
                        throw new DMNException ($"Expression {item.Expression.GetType()} is not supported yet");
                }
            }

            return contextout;
        }

        public static Variable EvalBkm (TBusinessKnowledgeModel bkmModel, VariableContext runtimeContext, List<Variable> inputParamVars) {

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

                default:
                    throw new DMNException ($"Expression {bkmModel.EncapsulatedLogic.Expression.GetType()} is not supported yet");
            }

        }

    }

}