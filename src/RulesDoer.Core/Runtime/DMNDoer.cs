using System.Collections.Generic;
using System.Collections.ObjectModel;
using RulesDoer.Core.Repo;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime {
    public class DMNDoer {

        private readonly DMNRepository _repository;

        public DMNDoer (DMNRepository repository) {

            _repository = repository;
        }

        public VariableContext BuildContext (string definitionName, int? versionNo = null) {

            var metaDef = BuildInputMeta (definitionName, versionNo);
            var definitions = metaDef.Item2;

            BuildDRGMeta (definitions, metaDef.Item1);

            metaDef.Item1.Done = true;

            return metaDef.Item1;
        }

        public Dictionary<string, Variable> EvaluateDecisions (VariableContext inRuntimeContext, string definitionName, int? versionNo = null, string decisionName = null) {

            var runtimeContext = BuildContext (definitionName, versionNo);

            if (inRuntimeContext != null) {
                //Copy the values from from input context
                runtimeContext.InputNameDict = inRuntimeContext.InputNameDict;

            }

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

        private void BuildDRGMeta (TDefinitions definitions, VariableContext context) {
            foreach (var item in definitions.DrgElement) {
                if (item is TDecisionService decisionService) {
                    context.DecisionServiceMetaByName.Add (decisionService.Name, decisionService);
                    foreach (var inputDecision in decisionService.InputDecision) {
                        var cleanHref = inputDecision.Href.TrimStart ('#');
                        if (!context.HrefInputDecisionToDecisionServices.TryAdd (cleanHref, new List<string> () { decisionService.Name })) {
                            context.HrefInputDecisionToDecisionServices.TryGetValue (cleanHref, out var decServices);
                            decServices.Add (decisionService.Name);
                        }
                    }
                }

                if (item is TDecision decision) {
                    context.DecisionMetaByName.Add (decision.Name, decision);
                    if (decision.Id != null) {
                        context.DecisionMetaById.Add (decision.Id, decision);
                    }
                }

                if (item is TBusinessKnowledgeModel bkmModel) {
                    context.BKMMetaByName.Add (bkmModel.Name, new BkmMeta () { BKMModel = bkmModel });
                }
            }
        }

        public (Dictionary<string, TDecision>, Dictionary<string, TDecision>) BuildDecisionMeta (TDefinitions definitions) {
            var decisionDict = new Dictionary<string, TDecision> ();
            var decisionDictById = new Dictionary<string, TDecision> ();
            foreach (var item in definitions.DrgElement) {
                if (item is TDecision decision) {
                    decisionDict.Add (decision.Name, decision);
                    if (decision.Id != null) {
                        decisionDict.Add (decision.Id, decision);
                    }
                }
            }
            return (decisionDict, decisionDictById);
        }

        public (Dictionary<string, TDecisionService>, Dictionary<string, TDecisionService>) BuildDecisionServiceMeta (TDefinitions definitions) {
            var decisionDict = new Dictionary<string, TDecisionService> ();
            var decisionDictById = new Dictionary<string, TDecisionService> ();
            foreach (var item in definitions.DrgElement) {
                if (item is TDecisionService decision) {
                    decisionDict.Add (decision.Name, decision);
                    if (decision.Id != null) {
                        decisionDict.Add (decision.Id, decision);
                    }
                }
            }
            return (decisionDict, decisionDictById);
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
                    var inputMeta = new InputDataMeta {
                        Id = inputDataItem.Id,
                        Name = inputDataItem.Name,
                        TypeName = inputDataItem.Variable.TypeRef
                    };
                    inputById.Add (inputMeta.Id, inputMeta);
                    inputByName.Add (inputMeta.Name, inputMeta);

                }

            }

            return (inputByName, inputById);
        }

        private Dictionary<string, ItemDefinitionMeta> BuildItemDefinitionsMeta (TDefinitions definitions) {
            var itemDefMetaDict = new Dictionary<string, ItemDefinitionMeta> ();
            foreach (var item in definitions.ItemDefinition) {
                var itemDefMeta = new ItemDefinitionMeta {
                    AllowedValues = item.AllowedValues,
                    Name = item.Name,
                    TypeName = item.TypeRef,
                    TypeLanguage = item.TypeLanguage,
                    IsCollection = item.IsCollection
                };
                CreateItemDefinitionMeta (item.ItemComponent, ref itemDefMeta);
                itemDefMetaDict.Add (item.Name, itemDefMeta);

            }
            return itemDefMetaDict;
        }

        private void CreateItemDefinitionMeta (Collection<TItemDefinition> itemDefs, ref ItemDefinitionMeta itemMeta) {
            var dict = new Dictionary<string, ItemDefinitionMeta> ();
            foreach (var item in itemDefs) {
                var itemDefMeta = new ItemDefinitionMeta {
                    AllowedValues = item.AllowedValues,
                    Name = item.Name,
                    TypeName = item.TypeRef,
                    TypeLanguage = item.TypeLanguage,
                    IsCollection = item.IsCollection
                };
                CreateItemDefinitionMeta (item.ItemComponent, ref itemDefMeta);
                dict.Add (item.Name, itemDefMeta);
            }
            if (itemDefs.Count > 0) {
                itemMeta.ItemComponents = dict;
            }

        }

    }
}