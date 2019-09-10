using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class FlattenFunc : IFunc {
        public const string FuncName = "flatten";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            if (parameters[0].ListType ()) {
                var fL = new List<Variable> ();

                Flatten (parameters[0], fL);
                return fL;
            }

            throw new FEELException ("Cannot flatten a non list type");

        }

        private void Flatten (Variable input, List<Variable> fL) {

            if (!input.ListType ()) {
                fL.Add (input);
                return;
            }

            if (input.ListWithSingleTypedVariable ()) {
                fL.AddRange (input.ListVal);
                return;
            }

            foreach (var item in input.ListVal) {
                Flatten (item, fL);
            }

        }
    }
}