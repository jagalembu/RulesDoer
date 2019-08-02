using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime {
    public static class HitPolicyHelper {
        public static List<Dictionary<string, Variable>> Output (THitPolicy hitpolicyenum, List<Dictionary<string, Variable>> matchedList) {
            var outputList = new List<Dictionary<string, Variable>> ();

            switch (hitpolicyenum) {
            case THitPolicy.UNIQUE:
            if (matchedList.Count > 1) {
            throw new DMNException ("More that one rule matched the decision table for Unique hit policy");
                    }
                    outputList.Add (matchedList[0]);
                    return outputList;

                case THitPolicy.FIRST:
                    outputList.Add (matchedList[0]);
                    return outputList;

                default:
                    throw new DMNException ($"The following hit policy is not supported: {hitpolicyenum}");
            }

        }
    }
}