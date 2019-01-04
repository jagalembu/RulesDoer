using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class NumericLiteral : IExpression {
        public Variable Value { get; private set; }

        public NumericLiteral (string expression) {
            Value = new Variable(decimal.Parse(expression));
        }

        public void Execute (IAstVisitor visitor) {
            visitor.VisitNumericLiteral(this);
        }
    }
}