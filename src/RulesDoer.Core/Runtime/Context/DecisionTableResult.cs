using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
     //TODO: need to move to types namespace
    public class DecisionTableResult {
        public List<Dictionary<string, Variable>> MatchedList { get; set; }
        public List<Dictionary<string, Variable>> OutputResult { get; set; }
    }
}