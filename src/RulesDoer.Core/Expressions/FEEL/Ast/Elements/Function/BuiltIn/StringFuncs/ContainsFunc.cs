using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class ContainsFunc : IFunc {
        public const string FuncName = "contains";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            return parameters[0].StringVal.Contains (parameters[1]);
        }
    }
}