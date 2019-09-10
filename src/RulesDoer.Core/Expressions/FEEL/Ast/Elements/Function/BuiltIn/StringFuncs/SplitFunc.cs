using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class SplitFunc : IFunc {
        public const string FuncName = "split";

        public Variable Execute (List<Variable> parameters) {

            parameters.ExpectedParamCount (2);

            var sM = Regex.Split (parameters[0].StringVal, parameters[1].StringVal);

            // var strs = parameters[0].StringVal.Split (parameters[1].StringVal, StringSplitOptions.None);
            List<Variable> listStr = new List<Variable> ();
            foreach (var item in sM) {
                listStr.Add (new Variable (item));
            }

            return new Variable (listStr);

        }
    }
}