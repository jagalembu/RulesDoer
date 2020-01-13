using System.Collections.Generic;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime.Context {
    //TODO: need to move to types namespace
    public class ItemDefinitionMeta {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public string TypeLanguage { get; set; }
        public TUnaryTests AllowedValues { get; set; }
        public bool IsCollection { get; set; }
        public Dictionary<string, ItemDefinitionMeta> ItemComponents { get; set; } = new Dictionary<string, ItemDefinitionMeta>();
        public bool CheckAllowedValues (VariableContext context) {
            //TODO: Need to execute unary test with context value and input name
            return true;
        }

    }
}