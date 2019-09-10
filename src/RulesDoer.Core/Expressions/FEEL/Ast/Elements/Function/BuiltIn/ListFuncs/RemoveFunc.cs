using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class RemoveFunc : IFunc {
        public const string FuncName = "remove";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            if (parameters[0].ListType ()) {
                parameters[1].ExpectedDataType (DataTypeEnum.Decimal);

                var x = parameters[1].NumericVal - 1;
                parameters[0].ListVal.RemoveAt ((int) x);
                return parameters[0].ListVal;

            }
            throw new FEELException ($"Failed removing item due to wrong type: {parameters[0].ValueType}");
        }
    }
}