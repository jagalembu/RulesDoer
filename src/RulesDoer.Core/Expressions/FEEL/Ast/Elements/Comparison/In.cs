namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison
{
    public class In : IComparisonExpression
    {
        public void Execute(IAstVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}