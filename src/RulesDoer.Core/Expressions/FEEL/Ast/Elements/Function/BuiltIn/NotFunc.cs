using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn {
    public class NotFunc : IFunc {
        public const string FuncName = "not";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            return !parameters[0];
        }

    }
}