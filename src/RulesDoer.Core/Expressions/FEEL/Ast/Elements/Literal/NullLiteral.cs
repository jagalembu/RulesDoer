using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class NullLiteral : IExpression {

        public NullLiteral () { }

        public void Execute (IAstVisitor visitor) {
            visitor.VisitNullLiteral(this);
        }
    }
}