using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.DateFuncs {
    public class DurationFunc : IFunc {
        public const string FuncName = "duration";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);

            return DateAndTimeHelper.DurationVal (parameters[0].StringVal);
        }
    }
}