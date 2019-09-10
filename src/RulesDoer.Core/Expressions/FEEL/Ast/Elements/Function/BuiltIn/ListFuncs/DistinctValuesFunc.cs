using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class DistinctValuesFunc : IFunc {
        public const string FuncName = "distinct values";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            if (parameters[0].ListType ()) {
                return parameters[0].ListVal.Distinct ().ToList ();
            }
            throw new FEELException ($"Failed distinct values when the parameter is not a list type but: {parameters[0].ValueType}");
        }
    }
}