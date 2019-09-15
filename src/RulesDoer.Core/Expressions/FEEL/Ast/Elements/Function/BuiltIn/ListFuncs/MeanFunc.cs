using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class MeanFunc : IFunc {
        public const string FuncName = "mean";
        public Variable Execute (List<Variable> parameters) {
            if (!parameters[0].IsListType()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum>() {DataTypeEnum.Decimal});
                return MathHelper.Mean (parameters);
            }

            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);
            return MathHelper.Mean (parameters[0].ListVal);
        }
    }
}