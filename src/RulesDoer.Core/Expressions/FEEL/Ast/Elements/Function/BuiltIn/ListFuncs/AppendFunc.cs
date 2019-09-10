using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class AppendFunc : IFunc {
        public const string FuncName = "append";

        public Variable Execute (List<Variable> parameters) {
            if (parameters[0].ListType () && parameters.Count > 1) {
                var appendItems = parameters.GetRange (1, parameters.Count - 1);

                var parentL = parameters[0].ListVal.GetRange(0, parameters[0].ListVal.Count);
                parentL.AddRange(appendItems);
                return parentL;

                //  parameters[0].ListVal.AddRange (appendItems);
                //  return parameters[0].ListVal;
            }

            throw new FEELException ("Expected a list in the first parameters for append function or missing appended items");
        }
    }
}