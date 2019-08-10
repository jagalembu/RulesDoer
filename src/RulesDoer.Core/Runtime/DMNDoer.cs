using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Repo;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Serialization;
using RulesDoer.Core.Transformer.v1_2;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime {
    public class DMNDoer {
        private readonly Evaluation _feelExpression;
        private readonly DMNRepository _repository;

        public DMNDoer (Evaluation feelExpression, DMNRepository repository) {
            _feelExpression = feelExpression;
            _repository = repository;
        }

        public Dictionary<string, Variable> EvaluateDecisions (VariableContext runtimeContext, string definitionName, int? versionNo = null, string decisionName = null) {

            var metaDef = BuildInputMeta (definitionName, versionNo);
            var definitions = metaDef.Item2;

            runtimeContext.InputDataMetaById = metaDef.Item1.InputDataMetaById;
            runtimeContext.InputDataMetaByName = metaDef.Item1.InputDataMetaByName;
            runtimeContext.ItemDefinitionMeta = metaDef.Item1.ItemDefinitionMeta;

            //TODO: check inputs match input data

            var results = new Dictionary<string, Variable> ();
            //evaluate decisions
            //TODO: Needs to handle calls to individual decision by name
            foreach (var item in definitions.DrgElement) {
                if (item is TDecision decision) {
                    if (decisionName != null && decision.Name != decisionName) {
                        continue;
                    }
                    switch (decision.Expression) {
                        case TLiteralExpression litExpr:
                            results.Add (decision.Name, _feelExpression.EvaluateExpressionsBase (litExpr.Text, runtimeContext));
                            break;

                        case TDecisionTable decisionTable:
                            results.Add (decision.Name, EvalDecisionTable (decisionTable, runtimeContext));
                            break;

                        default:
                            throw new DMNException ($"Decision expression {decision.Expression.Id} is not supported yet");
                    }

                }

            }

            return results;
        }

        public (VariableContext, TDefinitions) BuildInputMeta (string definitionName, int? versionNo = null) {
            var metaContext = new VariableContext ();

            //TODO: cache candidate
            var definitions = _repository.FindDefinitions (definitionName, versionNo);

            if (definitions.ItemDefinitionSpecified) {
                metaContext.ItemDefinitionMeta = BuildItemDefinitionsMeta (definitions);
            }

            var inputDicts = BuildInputDataMeta (definitions);
            metaContext.InputDataMetaByName = inputDicts.Item1;
            metaContext.InputDataMetaById = inputDicts.Item2;

            //TODO: meta context is a cachd candidate
            return (metaContext, definitions);
        }

        private (Dictionary<string, InputDataMeta>, Dictionary<string, InputDataMeta>) BuildInputDataMeta (TDefinitions definitions) {
            var inputById = new Dictionary<string, InputDataMeta> ();
            var inputByName = new Dictionary<string, InputDataMeta> ();

            foreach (var item in definitions.DrgElement) {
                if (item is TInputData inputDataItem) {
                    var inputMeta = new InputDataMeta ();
                    inputMeta.Id = inputDataItem.Id;
                    inputMeta.Name = inputDataItem.Name;
                    inputMeta.TypeName = inputDataItem.Variable.TypeRef;
                    inputById.Add (inputMeta.Id, inputMeta);
                    inputByName.Add (inputMeta.Name, inputMeta);

                }

            }

            return (inputByName, inputById);
        }

        private Dictionary<string, ItemDefinitionMeta> BuildItemDefinitionsMeta (TDefinitions definitions) {
            var itemDefMetaDict = new Dictionary<string, ItemDefinitionMeta> ();
            foreach (var item in definitions.ItemDefinition) {
                var itemDefMeta = new ItemDefinitionMeta ();
                itemDefMeta.AllowedValues = item.AllowedValues;
                itemDefMeta.Name = item.Name;
                itemDefMeta.TypeName = item.TypeRef;
                itemDefMeta.TypeLanguage = item.TypeLanguage;
                itemDefMeta.IsCollection = item.IsCollection;
                CreateItemDefinitionMeta (item.ItemComponent, ref itemDefMeta);
                itemDefMetaDict.Add (item.Name, itemDefMeta);

            }
            return itemDefMetaDict;
        }

        private void CreateItemDefinitionMeta (Collection<TItemDefinition> itemDefs, ref ItemDefinitionMeta itemMeta) {
            var dict = new Dictionary<string, ItemDefinitionMeta> ();
            foreach (var item in itemDefs) {
                var itemDefMeta = new ItemDefinitionMeta ();
                itemDefMeta.AllowedValues = item.AllowedValues;
                itemDefMeta.Name = item.Name;
                itemDefMeta.TypeName = item.TypeRef;
                itemDefMeta.TypeLanguage = item.TypeLanguage;
                itemDefMeta.IsCollection = item.IsCollection;
                CreateItemDefinitionMeta (item.ItemComponent, ref itemDefMeta);
                dict.Add (item.Name, itemDefMeta);
            }
            if (itemDefs.Count > 0) {
                itemMeta.ItemComponents = dict;
            }

        }

        private Variable EvalDecisionTable (TDecisionTable decisionTable, VariableContext runtimeContext) {
            var outputList = new List<Variable> ();
            var matchedList = new List<Dictionary<string, Variable>> ();
            if (decisionTable.HitPolicy == THitPolicy.PRIORITY || decisionTable.HitPolicy == THitPolicy.OUTPUT_ORDER) {
                var outcnt = decisionTable.Output.Count;
                for (int i = 0; i < decisionTable.Output.Count; i++) {
                    if (decisionTable.Output[i].OutputValues != null) {
                        var itemlist = _feelExpression.EvaluateSimpleExpressionsBase (decisionTable.Output[i].OutputValues.Text, runtimeContext);
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
                    matched = _feelExpression.EvaluateUnaryTestsBase (rule.InputEntry[i].Text, runtimeContext, decisionTable.Input[i].InputExpression.Text);
                    if (!matched) {
                        break;
                    }
                }

                if (matched) {
                    var outputDict = new Dictionary<string, Variable> ();
                    int prioritySum = 0;
                    for (int i = 0; i < decisionTable.Output.Count; i++) {
                        var outName = (decisionTable.Output[i].Name != null) ? decisionTable.Output[i].Name : i.ToString ();
                        var outVar = _feelExpression.EvaluateExpressionsBase (rule.OutputEntry[i].Text, runtimeContext);
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

                if (dtr.OutputResult.Count == 1 && dtr.OutputResult[0].Count == 1) {
                    foreach (var item in dtr.OutputResult[0]) {
                        return item.Value;
                    }

                }

                return dtr;
            }

            return null;
        }
    }
}