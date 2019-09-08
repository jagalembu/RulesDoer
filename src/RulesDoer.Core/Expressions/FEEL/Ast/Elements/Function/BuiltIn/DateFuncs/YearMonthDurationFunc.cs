using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.DateFuncs {
    public class YearMonthDurationFunc : IFunc {
        public const string FuncName = "years and months duration";

        public Variable Execute (List<Variable> parameters) {
            return DateAndTimeHelper.YearMonthDurationFunction (parameters);

        }
    }
}