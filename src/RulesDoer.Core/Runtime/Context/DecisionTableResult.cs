using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public class DecisionTableResult {
        public List<Dictionary<string, Variable>> MatchedList { get; set; }
        public List<Dictionary<string, Variable>> OutputResult { get; set; }
    }
}