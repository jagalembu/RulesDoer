namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison {
    public class Between : IComparisonExpression {
        public IExpression InputValue { get; private set; }
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public Between (IExpression value, IExpression left, IExpression right) {
            InputValue = value;
            Left = left;
            Right = right;

        }

        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}