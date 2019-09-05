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

        private readonly DMNRepository _repository;

        public DMNDoer (DMNRepository repository) {

            _repository = repository;
        }

        public Dictionary<string, Variable> EvaluateDecisions (VariableContext runtimeContext, string definitionName, int? versionNo = null, string decisionName = null) {

            var metaDef = BuildInputMeta (definitionName, versionNo);
            var definitions = metaDef.Item2;

            runtimeContext.InputDataMetaById = metaDef.Item1.InputDataMetaById;
            runtimeContext.InputDataMetaByName = metaDef.Item1.InputDataMetaByName;
            runtimeContext.ItemDefinitionMeta = metaDef.Item1.ItemDefinitionMeta;
            runtimeContext.BKMMetaByName = BuildBkmMeta (definitions);
            runtimeContext.DecisionMetaByName = BuildDecisionMeta (definitions);

            //TODO: check inputs match input data

            var results = new Dictionary<string, Variable> ();

            if (decisionName != null) {
                results.Add (decisionName, DMNDoerHelper.EvaluateDecisionByName (runtimeContext, decisionName));
                return results;
            }

            results = EvaluateDecisions (runtimeContext);

            return results;
        }

        public Dictionary<string, Variable> EvaluateDecisions (VariableContext runtimeContext) {
            var results = new Dictionary<string, Variable> ();
            foreach (var item in runtimeContext.DecisionMetaByName.Keys) {
                results.Add (item, DMNDoerHelper.EvaluateDecisionByName (runtimeContext, item));
            }

            return results;
        }

        public Dictionary<string, BkmMeta> BuildBkmMeta (TDefinitions definitions) {
            var bkmDict = new Dictionary<string, BkmMeta> ();

            foreach (var item in definitions.DrgElement) {
                if (item is TBusinessKnowledgeModel bkmModel) {
                    bkmDict.Add (bkmModel.Name, new BkmMeta () { BKMModel = bkmModel });
                }

            }

            return bkmDict;
        }

        public Dictionary<string, TDecision> BuildDecisionMeta (TDefinitions definitions) {
            var decisionDict = new Dictionary<string, TDecision> ();
            foreach (var item in definitions.DrgElement) {
                if (item is TDecision decision) {
                    decisionDict.Add (decision.Name, decision);
                }
            }
            return decisionDict;
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

    }
}