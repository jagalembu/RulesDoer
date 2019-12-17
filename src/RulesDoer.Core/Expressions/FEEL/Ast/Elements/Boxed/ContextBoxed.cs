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

            if (context == null) {
                context = new VariableContext ();
            }

            if (context.LocalContext == null) {
                context.LocalContext = contextInput;
            } else if (context.LocalContext.ContextDict.ContainsKey ("__currentContextX__")) {
                context.LocalContext.ContextDict["__currentContextX__"] = contextInput;
            } else {
                context.LocalContext.Add ("__currentContextX__", contextInput);
            }

            foreach (var item in ContextEntries) {
                var itemVal = (Variable) item.Execute (context);
                contextInput.Add (itemVal.TwoTuple.a, itemVal.TwoTuple.b);
            }
            
            context.LocalContext.ContextDict.Remove("__currentContextX__");

            return new Variable (contextInput);
        }
    }
}