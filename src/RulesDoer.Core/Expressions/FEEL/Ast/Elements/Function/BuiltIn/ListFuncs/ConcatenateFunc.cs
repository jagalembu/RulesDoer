using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class ConcatenateFunc : IFunc {
        public const string FuncName = "concatenate";

        public Variable Execute (List<Variable> parameters) {
            if (parameters.Count > 1) {

                var cL = new List<Variable> ();
                foreach (var item in parameters) {
                    if (!item.IsListType ()) {
                        throw new FEELException ("Expects a list type for concatenate function");
                    }
                    cL.AddRange (item.ListVal);
                }

                return cL;
            }

            throw new FEELException ("Expected more than one list parameters");
        }
    }
}