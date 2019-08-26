using System.Text.RegularExpressions;

namespace RulesDoer.Core.Utils {
    public static class StringUtils {
        public static string Unescape (string input) {
            if (input.StartsWith ("replace") || input.StartsWith ("matches")) {
                return input;
            }

            return Regex.Unescape (input);
        }
    }
}