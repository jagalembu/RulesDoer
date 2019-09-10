using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class ProductFunc : IFunc {
        public const string FuncName = "product";

        public Variable Execute (List<Variable> parameters) {
            if (!parameters[0].ListType ()) {
                parameters.ExpectedAllListItemType (new List<DataTypeEnum> () { DataTypeEnum.Decimal });
                return MathHelper.Product (parameters);
            }
            parameters.ExpectedParamCount (1);

            if (parameters[0].ListVal.Any ()) {
                parameters[0].ExpectedDataType (DataTypeEnum.ListDecimal);
                return MathHelper.Product (parameters[0].ListVal);
            }

            throw new FEELException ("Failed executing product function");

        }
    }
}