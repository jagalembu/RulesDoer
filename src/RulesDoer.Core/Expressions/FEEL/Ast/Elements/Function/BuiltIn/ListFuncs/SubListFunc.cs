using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class SubListFunc : IFunc {
        public const string FuncName = "sublist";

        public Variable Execute (List<Variable> parameters) {
            if (parameters[0].ListType () && parameters.Count <= 3) {
                var c = decimal.Zero;
                var i = decimal.Zero;

                parameters[1].ExpectedDataType (DataTypeEnum.Decimal);
                if (parameters[1].NumericVal > 0) {
                    i = parameters[1].NumericVal - 1;
                } else {
                    i = parameters[0].ListVal.Count  - (parameters[1].NumericVal * -1);
                }

                if (parameters.Count == 3) {
                    parameters[2].ExpectedDataType (DataTypeEnum.Decimal);
                    c = parameters[2].NumericVal;
                } else {
                    c = parameters[0].ListVal.Count - i;
                }

                return parameters[0].ListVal.GetRange ((int) i, (int) c);

            }
            throw new FEELException ($"Failed sublist function due to incorrect type:{parameters[0].ValueType} or count is greater than 3: {parameters.Count}");
        }
    }
}