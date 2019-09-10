using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class InsertBeforeFunc : IFunc {
        public const string FuncName = "insert before";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (3);
            if (parameters[0].ListType ()) {
                parameters[1].ExpectedDataType (DataTypeEnum.Decimal);
                var i = parameters[1].NumericVal - 1;
                var parentL = parameters[0].ListVal.GetRange(0, parameters[0].ListVal.Count);
                parentL.Insert ((int) i, parameters[2]);
                return parentL;
            }
            throw new FEELException ($"Failed due to incorrect type parameter: {parameters[1].ValueType}");
        }
    }
}