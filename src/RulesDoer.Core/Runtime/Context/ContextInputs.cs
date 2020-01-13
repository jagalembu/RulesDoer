using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    //TODO: need to move to types namespace
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
            if (!ContextDict.TryAdd (keyName, variable)) {
                ContextDict[keyName] = variable;
            }
            return this;
        }

    }
}