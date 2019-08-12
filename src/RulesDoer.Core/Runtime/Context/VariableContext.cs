using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public class VariableContext {
        public Dictionary<string, Variable> InputNameDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, Variable> GlobalDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, ItemDefinitionMeta> ItemDefinitionMeta { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaByName { get; set; }
        public Dictionary<string, InputDataMeta> InputDataMetaById { get; set; }
        public Dictionary<string, BkmMeta> BKMMetaByName { get; set; }

    }
}