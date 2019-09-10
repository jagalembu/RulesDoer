using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class SumFunc : IFunc {
        public const string FuncName = "sum";

        public Variable Execute (List<Variable> parameters) {
            if (parameters.Count > 1) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum> () { DataTypeEnum.Decimal });
                return parameters.Sum (x => x.NumericVal);
            }

            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);
            return parameters[0].ListVal.Sum (x => x.NumericVal);
        }
    }
}