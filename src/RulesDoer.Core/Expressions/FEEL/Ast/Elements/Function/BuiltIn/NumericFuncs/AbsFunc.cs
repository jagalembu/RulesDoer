using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class AbsFunc : IFunc {
        public const string FuncName = "abs";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.Decimal);
            return Math.Abs (parameters[0].NumericVal);
        }
    }
}