using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class MaxFunc : IFunc {
        public const string FuncName = "max";
        public Variable Execute (List<Variable> parameters) {

            if (!parameters[0].IsListType()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum>() {DataTypeEnum.Decimal});
                return parameters.Max (x => x.NumericVal);
            }

            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);

            return parameters[0].ListVal.Max (x => x.NumericVal);
        }
    }
}