using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public class VariableContext {
        public List<Variable> Variables { get; set; }

        public Dictionary<string, Variable> InputNameDict { get; set; }
    }
}