using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class ModuloFunc : IFunc {
        public const string FuncName = "modulo";
        public Variable Execute (List<Variable> parameters) {

            parameters.ExpectedParamCount (2);
            parameters[0].ExpectedDataType (DataTypeEnum.Decimal);
            parameters[1].ExpectedDataType (DataTypeEnum.Decimal);
             //return (x%m + m)%m;
            return (parameters[0].NumericVal % parameters[1].NumericVal + parameters[1].NumericVal)%parameters[1].NumericVal;

        }
    }
}