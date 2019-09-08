using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class StringFunc : IFunc {
        public const string FuncName = "string";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);

            return parameters[0].ToString ();
        }
    }
}