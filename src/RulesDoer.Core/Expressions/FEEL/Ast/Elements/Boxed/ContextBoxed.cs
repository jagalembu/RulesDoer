using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Boxed {
    public class ContextBoxed : IExpression {
        private readonly List<IExpression> ContextEntries;

        public ContextBoxed (List<IExpression> contextEntries) {
            ContextEntries = contextEntries;
        }

        public object Execute (VariableContext context = null) {

            var contextInput = new ContextInputs ();

            foreach (var item in ContextEntries) {
                var itemVal = (Variable) item.Execute ();
                contextInput.Add (itemVal.TwoTuple.a, itemVal.TwoTuple.b);
            }

            return new Variable (contextInput);
        }
    }
}