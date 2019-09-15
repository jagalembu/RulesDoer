using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class AllFunc : IFunc {
        public const string FuncName = "all";

        public Variable Execute (List<Variable> parameters) {
            if (!parameters[0].IsListType ()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum> () { DataTypeEnum.Boolean });
                return All (parameters);
            }
            parameters.ExpectedParamCount (1);

            if (parameters[0].ListVal.Any ()) {
                parameters[0].ExpectedDataType (DataTypeEnum.ListBoolean);
                return All (parameters[0].ListVal);
            }

            // then its empty
            return true;

        }

        private Variable All (List<Variable> variables) {
            foreach (var item in variables) {
                if (item.ValueType == DataTypeEnum.Boolean && item.BoolVal == false) {
                    return false;
                }
            }
            return true;
        }
    }
}