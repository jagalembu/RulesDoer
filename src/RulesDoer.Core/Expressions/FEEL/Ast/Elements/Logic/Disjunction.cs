namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Logic {
    public class Disjunction : ILogical {
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public Disjunction (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }
        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}