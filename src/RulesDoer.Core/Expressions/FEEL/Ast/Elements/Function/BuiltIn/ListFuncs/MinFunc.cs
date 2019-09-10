using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class MinFunc : IFunc {
        public const string FuncName = "min";

        public Variable Execute (List<Variable> parameters) {

            if (!parameters[0].ListType()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum>() {DataTypeEnum.Decimal});
                return parameters.Min (x => x.NumericVal);
            }

            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);

            return parameters[0].ListVal.Min (x => x.NumericVal);
        }
    }
}