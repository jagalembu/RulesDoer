using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class DecimalFunc : IFunc {
        public const string FuncName = "decimal";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            return Math.Round (parameters[0].NumericVal, (int) parameters[1].NumericVal);
        }
    }
}