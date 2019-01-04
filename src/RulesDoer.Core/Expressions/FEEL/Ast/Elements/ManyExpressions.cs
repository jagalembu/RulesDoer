using System.Collections.Generic;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class ManyExpressions : IExpression {
        public List<IExpression> ExpressionLists { get; set; } = new List<IExpression> ();

        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}