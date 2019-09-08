using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs {
    public class FloorFunc : IFunc {
        public const string FuncName = "floor";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            return Math.Floor (parameters[0].NumericVal);
        }
    }
}