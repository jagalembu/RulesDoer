using System.Collections.Generic;
using System.Text.RegularExpressions;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs {
    public class ReplaceFunc : IFunc {
        public const string FuncName = "replace";
        public Variable Execute (List<Variable> parameters) {
            RegexOptions flagOpts = RegexOptions.None;
            if (parameters.Count == 4) {
                flagOpts = StringUtils.MatchesOptions (parameters[3]);
            }
            if (parameters.Count == 3 || parameters.Count == 4) {
                return Regex.Replace (parameters[0], parameters[1], parameters[2], flagOpts);
            }
            throw new FEELException ($"Incorrect parameters:{parameters.Count} for {FuncName} function");
        }
    }
}