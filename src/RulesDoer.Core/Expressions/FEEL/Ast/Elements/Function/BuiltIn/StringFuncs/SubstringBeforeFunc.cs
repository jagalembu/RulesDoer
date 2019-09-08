using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class SubstringBeforeFunc : IFunc {
        public const string FuncName = "substring before";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            var indexStart = parameters[0].StringVal.IndexOf (parameters[1].StringVal);
            if (indexStart < 0) {
                return "";
            }
            return parameters[0].StringVal.Substring (0, indexStart);
        }
    }
}