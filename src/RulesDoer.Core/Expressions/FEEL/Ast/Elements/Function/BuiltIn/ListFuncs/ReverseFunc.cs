using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class ReverseFunc : IFunc {
        public const string FuncName = "reverse";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount(1);
            if (parameters[0].IsListType())
            {
                parameters[0].ListVal.Reverse();
                return parameters[0].ListVal;
            }
            throw new FEELException($"Incorrect type for reverse parameter: {parameters[0].ValueType}");
        }
    }
}