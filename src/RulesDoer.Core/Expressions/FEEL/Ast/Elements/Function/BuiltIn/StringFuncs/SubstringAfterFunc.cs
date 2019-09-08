using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class SubstringAfterFunc : IFunc {
        public const string FuncName = "substring after";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);

            var indexStart = parameters[0].StringVal.IndexOf (parameters[1].StringVal);
            if (indexStart < 0) {
                return "";
            }
            return parameters[0].StringVal.Substring (indexStart + parameters[1].StringVal.Length);
        }
    }
}