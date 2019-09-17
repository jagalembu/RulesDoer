using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Utils {
    public static class ListExtensions {
        public static void ExpectedParamCount (this List<Variable> lVars, int expectedCount) {
            if (lVars.Count != expectedCount) {
                throw new FEELException ($"The parameter count: {lVars.Count} does not match expected: {expectedCount}");
            }
        }

        public static void ExpectedAllListItemType (this List<Variable> lVars, List<DataTypeEnum> expectedTypes) {
            foreach (var item in lVars) {
                var matched = false;
                foreach (var dtype in expectedTypes) {
                    if (item.ValueType == dtype) {
                        matched = true;
                        break;
                    }
                }
                if (!matched) {
                    throw new FEELException ($"Failed list of variables does not match expected types");
                }
            }
        }

        public static List<Variable> SingletonListToVariable (this List<Variable> lVars) {
            List<Variable> singleItemVarList = new List<Variable> ();

            foreach (var item in lVars) {
                if (item.IsListType () && item.ListVal.Count == 1) {
                    singleItemVarList.Add (item.ListVal[0]);
                } else {
                    singleItemVarList.Add (item);
                }
            }
            return singleItemVarList;

        }

    }
}