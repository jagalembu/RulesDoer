using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class IndexOfFunc : IFunc {
        public const string FuncName = "index of";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            if (!parameters[0].IsListType ()) {
                throw new FEELException ($"Expected first parameter to be a list: {parameters[0].ValueType}");
            }

            var indeOfL = new List<Variable> ();
            var x = 0;
            do {
                x = parameters[0].ListVal.IndexOf (parameters[1], x);
                if (x > -1) {
                    indeOfL.Add (x);
                }
            } while (x > -1);

            if (indeOfL.Any ()) {
                return indeOfL;
            }

            return new Variable();
        }
    }
}