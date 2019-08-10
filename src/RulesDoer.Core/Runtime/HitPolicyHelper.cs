using System;
using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Runtime {
    public static class HitPolicyHelper {
        public static List<Dictionary<string, Variable>> Output (THitPolicy hitpolicyenum, List<Dictionary<string, Variable>> matchedList, TBuiltinAggregator? agg = null) {
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

                case THitPolicy.ANY:
                    // all matched outputs must be same output
                    foreach (var item1 in matchedList) {
                        foreach (var dict1 in item1) {
                            foreach (var item2 in matchedList) {
                                item2.TryGetValue (dict1.Key, out var dict2Val);
                                if (!dict1.Value.Equals (dict2Val)) {
                                    throw new DMNException ("Any hit policy expects the same output");
                                }
                            }
                        }
                    }

                    outputList.Add (matchedList[0]);
                    return outputList;

                case THitPolicy.PRIORITY:
                    Variable priorityVal = 0;
                    int lastIndex = 0;
                    for (int i = 0; i < matchedList.Count; i++) {
                        matchedList[i].TryGetValue ("__p__", out var pVal);
                        if (pVal > priorityVal) {
                            priorityVal = pVal;
                            lastIndex = i;
                        }
                    }
                    var pDict = new Dictionary<string, Variable> (matchedList[lastIndex]);
                    pDict.Remove ("__p__");

                    outputList.Add (pDict);
                    return outputList;

                case THitPolicy.RULE_ORDER:

                    outputList.AddRange (matchedList);
                    return outputList;

                case THitPolicy.OUTPUT_ORDER:

                    var sortedList = matchedList.OrderByDescending (d => d["__p__"]);

                    var outputOrderList = new List<Dictionary<string, Variable>> ();

                    foreach (var item in sortedList) {
                        var outputOrderDict = new Dictionary<string, Variable> ();
                        foreach (var dict in item) {
                            if (dict.Key != "__p__") {
                                outputOrderDict.Add (dict.Key, dict.Value);
                            }
                        }
                        outputOrderList.Add (outputOrderDict);
                    }

                    outputList.AddRange (outputOrderList);
                    return outputList;

                case THitPolicy.COLLECT:
                    var outD = new Dictionary<string, Variable> ();
                    if (agg.HasValue) {
                        switch (agg.Value) {
                            case TBuiltinAggregator.COUNT:
                                outD.Add ("__c__", matchedList.Count);
                                outputList.Add (outD);
                                return outputList;
                            case TBuiltinAggregator.SUM:
                                var sumD = matchedList.SelectMany (d => d)
                                    .GroupBy (kvp => kvp.Key, kvp => kvp.Value);
                                foreach (var item in sumD) {
                                    var total = item.Sum (x => x.NumericVal);
                                    outD.Add (item.Key, total);
                                }
                                outputList.Add (outD);
                                return outputList;
                            case TBuiltinAggregator.MAX:
                                var maxD = matchedList.SelectMany (d => d)
                                    .GroupBy (kvp => kvp.Key, kvp => kvp.Value)
                                    .ToDictionary (g => g.Key, g => g.Max ());
                                outputList.Add (maxD);
                                return outputList;
                            case TBuiltinAggregator.MIN:
                                var minD = matchedList.SelectMany (d => d)
                                    .GroupBy (kvp => kvp.Key, kvp => kvp.Value)
                                    .ToDictionary (g => g.Key, g => g.Min ());
                                outputList.Add (minD);
                                return outputList;
                            case TBuiltinAggregator.NONE:
                                outputList.AddRange (matchedList);
                                return outputList;
                        }

                    }
                    throw new DMNException ($"Collect hit policy need an aggregator");

                default:
                    throw new DMNException ($"The following hit policy is not supported: {hitpolicyenum}");
            }

        }
    }
}