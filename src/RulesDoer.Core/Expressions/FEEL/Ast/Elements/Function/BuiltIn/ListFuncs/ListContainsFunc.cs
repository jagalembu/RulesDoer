using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class ListContainsFunc : IFunc {
        public const string FuncName = "list contains";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            if (parameters[0].ListType())
            {
                return parameters[0].ListVal.Contains (parameters[1]);
            }

            throw new FEELException($"Not a list type but:{parameters[0].ValueType} for contains function.");
        }
    }
}