using System.Collections.Generic;
using System.Text.RegularExpressions;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class MatchesFunc : IFunc {
        public const string FuncName = "matches";
        public Variable Execute (List<Variable> parameters) {
            RegexOptions flags_m = RegexOptions.None;
            if (parameters.Count == 3) {
                flags_m = StringUtils.MatchesOptions (parameters[2]);
            }
            if (parameters.Count <= 3) {
                var matchesFnd = Regex.Match (parameters[0], parameters[1], flags_m);
                return matchesFnd.Success;
            }
            throw new FEELException ($"Incorrect parameters: {parameters.Count} for {FuncName} function");
        }
    }
}