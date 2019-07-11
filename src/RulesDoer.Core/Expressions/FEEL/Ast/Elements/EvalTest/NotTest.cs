using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class NotTest : ITestExpression {

        private readonly ITestExpression Expression;

        public NotTest (ITestExpression expression) {
            Expression = expression;
        }

        public bool Execute (VariableContext context = null, string inputName = null) {
            return !Expression.Execute (context, inputName);
        }

    }
}