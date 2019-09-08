using System.Text.RegularExpressions;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Utils {
    public static class StringUtils {
        public static string Unescape (string input) {
            if (input.StartsWith ("replace") || input.StartsWith ("matches")) {
                return input;
            }

            return Regex.Unescape (input);
        }

        public static RegexOptions MatchesOptions (Variable flagExpr) {

            if (flagExpr.ValueType == DataTypeEnum.String) {
                RegexOptions opts = RegexOptions.None;
                foreach (char item in flagExpr.StringVal) {
                    switch (item) {
                        case 's':
                            opts |= RegexOptions.Singleline;
                            break;
                        case 'm':
                            opts |= RegexOptions.Multiline;
                            break;
                        case 'i':
                            opts |= RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
                            break;
                        case 'x':
                            opts |= RegexOptions.IgnorePatternWhitespace;
                            break;

                        default:
                            throw new FEELException ($"Regex option {item} is not supported");
                    }
                }

                return opts;

            }

            throw new FEELException ("Regex option flag is incorrect type");
        }

    }
}