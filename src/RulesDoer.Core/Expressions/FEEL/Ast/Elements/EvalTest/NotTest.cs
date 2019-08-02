using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class NotTest : ITestExpression {

        private readonly ITestExpression Expression;

        public NotTest (ITestExpression expression) {
            Expression = expression;
        }

        public object Execute (VariableContext context = null, string inputName = null) {
            return new Variable(!((Variable)Expression.Execute (context, inputName)).BoolVal);
        }

    }
}