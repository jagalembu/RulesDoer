using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Utils {
    public static class ListExtensions {
        public static void ExpectedParamCount (this List<Variable> lVars, int expectedCount) {
            if (lVars.Count != expectedCount) {
                throw new FEELException ($"The parameter count: {lVars.Count} does not match expected: {expectedCount}");
            }
        }
    }
}