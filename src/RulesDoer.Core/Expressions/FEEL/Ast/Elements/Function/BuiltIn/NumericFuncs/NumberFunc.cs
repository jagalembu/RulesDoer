using System;
using System.Collections.Generic;
using System.Globalization;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class NumberFunc : IFunc {
        public const string FuncName = "number";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (3);
            parameters[0].ExpectedDataType (DataTypeEnum.String);

            if (parameters[1].ValueType != DataTypeEnum.String && parameters[1].ValueType != DataTypeEnum.Null) {
                throw new FEELException ("Only string or null type is accepted for grouping separator");
            }

            if (parameters[2].ValueType != DataTypeEnum.String && parameters[2].ValueType != DataTypeEnum.Null) {
                throw new FEELException ("Only string or null type is accepted for decimal separator");
            }

            var numStr = parameters[0].StringVal;

            // if (parameters[1].ValueType == DataTypeEnum.String && !parameters[0].StringVal.Contains (parameters[1])) {
            //     throw new FEELException ("The grouping separator not found");
            // }

            // if (parameters[2].ValueType == DataTypeEnum.String && !parameters[0].StringVal.Contains (parameters[2])) {
            //     throw new FEELException ("The decimal separator not found");
            // }

            var nfi = new CultureInfo ("en-US", false).NumberFormat;

            if (parameters[1].ValueType == DataTypeEnum.String) {
                nfi.NumberGroupSeparator = parameters[1];
            }

            if (parameters[2].ValueType == DataTypeEnum.String) {
                // numStr = numStr.Replace (parameters[2].StringVal, ".");
                nfi.NumberDecimalSeparator = parameters[2];
            }

            return Decimal.Parse (numStr, nfi);

        }
    }
}