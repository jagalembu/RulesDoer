using System.Collections.Generic;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime.Context {
    public class VariableContext {
        public Dictionary<string, Variable> InputNameDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, Variable> GlobalDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, ItemDefinitionMeta> ItemDefinitionMeta { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaByName { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaById { get; set; }
        public Dictionary<string, BkmMeta> BKMMetaByName { get; set; }
        public Dictionary<string, TDecision> DecisionMetaByName { get; set; }

    }
}