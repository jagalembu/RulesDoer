using System;
using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Utils {
    public static class MathHelper {

        public static Variable StdDev (List<Variable> lVars) {

            var meanV = Mean (lVars);
            var variance = Decimal.Zero;
            foreach (var item in lVars) {
                var sM = item.NumericVal - meanV.NumericVal;
                var vM = sM * sM;
                variance += vM;
            }
            variance = variance / (lVars.Count () - 1);
            var stdDevT = Math.Sqrt ((Double) variance);

            return new decimal (stdDevT);
        }

        public static Variable Mode (List<Variable> lVars) {
            if (lVars.Count == 1) {
                return lVars;
            }
            var vCountL = lVars.GroupBy (k => k.NumericVal).OrderByDescending (k => k.Count ()).Select (s => (s.Key, s.Count ())).ToList ();

            var outL = new List<Variable> ();

            var maxCount = vCountL[0].Item2;
            outL.Add (vCountL[0].Key);

            for (int i = 1; i < vCountL.Count; i++) {
                if (vCountL[i].Item2 == maxCount) {
                    outL.Add (vCountL[i].Key);
                }
            }
            outL.Sort ();
            return outL;
        }

        public static Variable Mean (List<Variable> numList) {

            return numList.Average (v => v.NumericVal);
        }

        public static Variable Product (List<Variable> numList) {

            var tot = Decimal.Zero;
            foreach (var item in numList) {
                tot = tot * item;
            }
            return tot;
        }

        public static Variable Median (List<Variable> lVars) {
            if (lVars.Count == 1) {
                return lVars[0];
            }

            lVars.Sort ();
            if (lVars.Count % 2 == 0) {
                var midPos = lVars.Count / 2;
                var fPos = lVars[midPos - 1];
                var sPos = lVars[midPos];

                return (fPos.NumericVal + sPos.NumericVal) / 2;
            }
            var middlePos = lVars.Count / 2;
            return lVars[middlePos];
        }

        public static Variable Pow (decimal left, decimal right) {
            //var x = Decimal.Parse (rightVal.NumericVal.ToString ());
            var x = Decimal.Parse (right.ToString ());
            decimal powV = 1;
            if (x < 0) {
                x = x * -1;
            }

            for (; x > 0; x--) {
                powV *= left;
            }
            if (right < 0) {
                powV = 1 / powV;
            }
            return new Variable (powV);
        }

    }
}