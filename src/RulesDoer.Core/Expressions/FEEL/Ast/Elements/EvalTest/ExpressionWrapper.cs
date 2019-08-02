using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class ExpressionWrapper : ITestExpression {
        private readonly IExpression Expression;
        public ExpressionWrapper (IExpression expression) {
            Expression = expression;
        }

        public object Execute (VariableContext context = null) {
            return Expression.Execute (context);
        }

        public object Execute (VariableContext context = null, string inputName = null) {
            throw new System.NotImplementedException ();
        }
    }
}