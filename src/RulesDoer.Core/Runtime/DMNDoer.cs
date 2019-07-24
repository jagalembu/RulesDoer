using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Repo;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Serialization;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime {
    public class DMNDoer {
        private readonly Evaluation _feelExpression;
        private readonly DMNRepository _repository;

        public DMNDoer (Evaluation feelExpression, DMNRepository repository) {
            _feelExpression = feelExpression;
            _repository = repository;
        }

        public Dictionary<string, Variable> EvaluateDecisions (VariableContext runtimeContext, string definitionName, int? versionNo = null) {

            var definitions = _repository.FindDefinitions (definitionName, versionNo);

            //build item definition meta
            if (definitions.ItemDefinitionSpecified) {
                runtimeContext.ItemDefinitionMeta = BuildItemDefinitionsMeta (definitions);
            }

            //build input data meta
            var inputDicts = BuildInputDataMeta (definitions);
            runtimeContext.InputDataMetaById = inputDicts.Item1;
            runtimeContext.InputDataMetaByName = inputDicts.Item2;

            //check inputs match input data

            var results = new Dictionary<string, Variable> ();
            //evaluate decisions
            foreach (var item in definitions.DrgElement) {
                if (item is TDecision decision) {
                    switch (decision.Expression) {
                        case TLiteralExpression litExpr:
                            results.Add (decision.Name, _feelExpression.EvaluateExpressionsBase (litExpr.Text, runtimeContext));
                            break;

                        default:
                            throw new DMNException ($"Decision expression {decision.Expression.Id} is not supported yet");
                    }

                }

            }

            return results;
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
                itemDefMeta.TypeLanguage = item.TypeRef;
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
                itemDefMeta.TypeLanguage = item.TypeRef;
                itemDefMeta.TypeLanguage = item.TypeLanguage;
                itemDefMeta.IsCollection = item.IsCollection;
                CreateItemDefinitionMeta (item.ItemComponent, ref itemDefMeta);
                dict.Add (item.Name, itemDefMeta);
            }
            if (itemDefs.Count > 0) {
                itemMeta.ItemComponents = dict;
            }

        }
    }
}