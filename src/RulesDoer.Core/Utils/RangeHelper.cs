using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Utils {
    public static class RangeHelper {
        public static IEnumerable<Variable> Decimal (decimal from, decimal to) {

            if (from <= to) {
                for (decimal m = from; m <= to; m += 1) yield return m;
            } else {
                for (decimal m = from; m >= to; m -= 1) yield return m;
            }
        }
    }
}