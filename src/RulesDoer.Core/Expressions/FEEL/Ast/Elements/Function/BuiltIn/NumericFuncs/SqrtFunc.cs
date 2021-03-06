using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class SqrtFunc : IFunc {
        public const string FuncName = "sqrt";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.Decimal);
            return new decimal (Math.Sqrt (Double.Parse (parameters[0].NumericVal.ToString ())));
        }
    }
}