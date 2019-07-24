using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public class ContextInputs {
        private readonly string Name = null;
        public Dictionary<string, Variable> ContextDict { get; set; } = new Dictionary<string, Variable> ();
        public bool IsItemDefinition { get; set; }
        public ContextInputs (string name) {
            Name = name;
        }

        public ContextInputs () {

        }

        public ContextInputs Add (string keyName, Variable variable) {
            ContextDict.Add (keyName, variable);
            return this;
        }

    }
}