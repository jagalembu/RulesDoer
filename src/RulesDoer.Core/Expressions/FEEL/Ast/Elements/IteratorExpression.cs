using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class IteratorExpression : IExpression {
        public string Name { get; set; }
        public IExpression Items { get; set; }
        public IteratorExpression (string name, IExpression items) {
            Name = name;
            Items = items;
        }

        public object Execute (VariableContext context = null) {
            var x = (Variable) Items.Execute (context);
            if (!x.IsListType ()) {
                throw new FEELException ("Expected a list variable for iterations");
            }
            return new Variable (new ContextInputs ().Add (Name, x));
        }
    }
}