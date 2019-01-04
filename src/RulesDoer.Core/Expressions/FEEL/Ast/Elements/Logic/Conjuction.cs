namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Logic {
    public class Conjuction : ILogical {
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public Conjuction (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }
        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}