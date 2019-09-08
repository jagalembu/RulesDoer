using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.DateFuncs {
    public class DateFunc : IFunc {
        public const string FuncName = "date";
        public Variable Execute (List<Variable> parameters) {
            return DateAndTimeHelper.DateFunction (parameters);
        }
    }
}