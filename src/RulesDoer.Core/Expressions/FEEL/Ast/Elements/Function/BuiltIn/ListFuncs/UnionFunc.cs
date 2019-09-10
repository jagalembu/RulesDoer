using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class UnionFunc : IFunc {
        public const string FuncName = "union";

        public Variable Execute (List<Variable> parameters) {
            var uL = new List<Variable> ();
            foreach (var item in parameters) {
                if (item.ListType ()) {
                    uL.AddRange (item.ListVal);
                }

            }
            var dL = uL.Distinct ().ToList ();
            return dL;
        }
    }
}