using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class SplitFunc : IFunc {
        public const string FuncName = "split";

        public Variable Execute (List<Variable> parameters) {

            parameters.ExpectedParamCount (2);

            var strs = parameters[0].StringVal.Split (parameters[1].StringVal, StringSplitOptions.None);
            List<Variable> listStr = new List<Variable> ();
            foreach (var item in strs) {
                listStr.Add (new Variable (item));
            }

            return new Variable (listStr);

        }
    }
}