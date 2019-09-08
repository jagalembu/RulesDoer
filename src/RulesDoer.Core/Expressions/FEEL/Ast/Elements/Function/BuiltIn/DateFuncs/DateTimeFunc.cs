using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.DateFuncs {
    public class DateTimeFunc : IFunc {
        public const string FuncName = "date and time";

        public Variable Execute (List<Variable> parameters) {
            return DateAndTimeHelper.DateTimeFunction (parameters);
        }
    }
}