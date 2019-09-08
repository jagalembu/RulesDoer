using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class OddFunc : IFunc {
        public const string FuncName = "odd";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.Decimal);
            return (parameters[0].NumericVal % 2 != 0);
        }
    }
}