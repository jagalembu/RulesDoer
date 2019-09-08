using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class SubstringFunc : IFunc {
        public const string FuncName = "substring";
        public Variable Execute (List<Variable> parameters) {
            if (parameters.Count == 2) {
                var startIndex = int.Parse (parameters[1].NumericVal.ToString ());
                return parameters[0].StringVal.Substring (startIndex > 0 ? startIndex - 1 : parameters[0].StringVal.Length - (startIndex * -1));
            }
            if (parameters.Count == 3) {
                var startIndex = int.Parse (parameters[1].NumericVal.ToString ());
                return parameters[0].StringVal.Substring (
                    startIndex > 0 ? startIndex - 1 : parameters[0].StringVal.Length - (startIndex * -1),
                    int.Parse (Math.Truncate (parameters[2].NumericVal).ToString ()));
            }
            throw new FEELException ($"Incorrect parameters for {FuncName} function");
        }
    }
}