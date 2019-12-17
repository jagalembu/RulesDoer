using System.Collections.Generic;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime.Context {
    public class VariableContext {
        public bool Done { get; set; } = false;
        public Dictionary<string, Variable> InputNameDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, Variable> GlobalDict { get; set; } = new Dictionary<string, Variable> ();
        public Dictionary<string, ItemDefinitionMeta> ItemDefinitionMeta { get; set; } = new Dictionary<string, ItemDefinitionMeta> ();
        public Dictionary<string, InputDataMeta> InputDataMetaByName { get; set; } = new Dictionary<string, InputDataMeta> ();
        public Dictionary<string, InputDataMeta> InputDataMetaById { get; set; } = new Dictionary<string, InputDataMeta> ();
        public Dictionary<string, BkmMeta> BKMMetaByName { get; set; } = new Dictionary<string, BkmMeta> ();
        public Dictionary<string, TDecision> DecisionMetaByName { get; set; } = new Dictionary<string, TDecision> ();
        public Dictionary<string, TDecision> DecisionMetaById { get; set; } = new Dictionary<string, TDecision> ();
        public Dictionary<string, TDecisionService> DecisionServiceMetaByName { get; set; } = new Dictionary<string, TDecisionService> ();
        public Dictionary<string, List<string>> HrefInputDecisionToDecisionServices { get; set; } = new Dictionary<string, List<string>> ();
        public ContextInputs LocalContext {get; set;}

    }
}