using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class StringLengthFunc : IFunc {
        public const string FuncName = "string length";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            return new Variable (parameters[0].StringVal.Length);
        }
    }
}