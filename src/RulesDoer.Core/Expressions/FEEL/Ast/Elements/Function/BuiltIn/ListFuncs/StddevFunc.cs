using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class StddevFunc : IFunc {
        public const string FuncName = "stddev";

        public Variable Execute (List<Variable> parameters) {
            if (!parameters[0].IsListType ()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum> () { DataTypeEnum.Decimal });
                return MathHelper.StdDev (parameters);
            }

            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);

            return MathHelper.StdDev (parameters[0].ListVal);
        }
    }
}