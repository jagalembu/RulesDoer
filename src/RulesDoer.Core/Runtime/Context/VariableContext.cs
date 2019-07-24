using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public class VariableContext {
        public Dictionary<string, Variable> InputNameDict { get; set; }
        public Dictionary<string, Variable> GlobalDict { get; set; }
        public Dictionary<string, ItemDefinitionMeta> ItemDefinitionMeta { get; set; }
        public Dictionary<string, Variable> DecisionResults { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaByName { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaById {get; set;}

    }
}