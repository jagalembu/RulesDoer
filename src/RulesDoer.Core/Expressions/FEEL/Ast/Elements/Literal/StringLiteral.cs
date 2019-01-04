using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class StringLiteral : IExpression {
        public Variable Value { get; private set; }

        public StringLiteral (string expression) {
            Value = new Variable(expression);
        }

        public void Execute (IAstVisitor visitor) {
            visitor.VisitStringLiteral(this);
        }
    }
}