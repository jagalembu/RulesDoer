using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class CountFunc : IFunc {
        public const string FuncName = "count";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            if (parameters[0].IsListType ()) {
                return parameters[0].ListVal.Count;
            }

            throw new FEELException ($"Failed count function due to incorrect type:{parameters[0].ValueType}");

        }
    }
}