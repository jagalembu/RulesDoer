using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class CeilingFunc : IFunc {
        public const string FuncName = "ceiling";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            return Math.Ceiling (parameters[0].NumericVal);
        }
    }
}