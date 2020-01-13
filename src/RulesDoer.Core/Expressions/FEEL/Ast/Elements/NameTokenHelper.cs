using System.Collections.Generic;
using System.Text;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public static class NameTokenHelper {
        public static string BuildNameToken (IList<string> names) {
            if (names.Count == 1) {
                return names[0];
            }

            var outName = new StringBuilder (names[0]);
            for (int i = 1; i < names.Count; i++) {
                outName.Append (" ");
                outName.Append (names[i]);

            }

            return outName.ToString ();

        }

    }
}