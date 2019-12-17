using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Utils {
    public static class CartesianProductHelper {

        public static IList < (string, int, Variable) > BuildNamedVariableList (IList<IExpression> expressions, VariableContext context) {
            var namedList = new List < (string, int, Variable) > ();

            foreach (var item in expressions) {
                var x = (Variable) item.Execute (context);

                x.ExpectedDataType (DataTypeEnum.Context);

                foreach (var kv in x.ContextInputs.ContextDict) {
                    if (!kv.Value.IsListType ()) {
                        throw new FEELException ("Expected collection of items");
                    }
                    namedList.Add ((kv.Key, kv.Value.ListVal.Count, kv.Value));
                }

            }
            return namedList;
        }

        public static IEnumerable<IEnumerable<(string,Variable)>> IterateDynamicLoop (IList < (string, int, Variable) > data) {
            var count = data.Count;

            var loopIndex = count - 1;
            var counters = new int[count];
            var bounds = data.Select (x => x.Item2).ToArray ();

            do {
                yield return Enumerable.Range (0, count).Select (x => (data[x].Item1,data[x].Item3.ListVal[counters[x]]));
            } while (IncrementLoopState (counters, bounds, ref loopIndex));
        }

        private static bool IncrementLoopState (IList<int> counters, IList<int> bounds, ref int loopIndex) {
            if (loopIndex < 0)
                return false;

            counters[loopIndex] = counters[loopIndex] + 1;

            var result = true;

            if (counters[loopIndex] >= bounds[loopIndex]) {
                counters[loopIndex] = 0;
                loopIndex--;
                result = IncrementLoopState (counters, bounds, ref loopIndex);
                loopIndex++;
            }

            return result;
        }

    }
}