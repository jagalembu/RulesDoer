namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison {
    public class Relational : IComparisonExpression {
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }
        public string Operator { get; private set; }

        public Relational (string op, IExpression left, IExpression right) {
            Operator = op;
            Left = left;
            Right = right;
        }
        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}