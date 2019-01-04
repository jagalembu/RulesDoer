using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class BooleanLiteral : IExpression {
        public Variable Value { get; private set; }

        public BooleanLiteral (string expression) {
            Value = new Variable (bool.Parse (expression));
        }

        public void Execute (IAstVisitor visitor) {
            visitor.VisitBooleanLiteral (this);
        }
    }
}