using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class ModeFunc : IFunc {
        public const string FuncName = "mode";

        public Variable Execute (List<Variable> parameters) {
            if (!parameters[0].ListType ()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum> () { DataTypeEnum.Decimal });
                return MathHelper.Mode (parameters);
            }

            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);

            return MathHelper.Mode (parameters[0].ListVal);
        }
    }
}