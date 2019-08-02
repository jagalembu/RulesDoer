using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class AnyTest : ITestExpression {
        public object Execute (VariableContext context = null, string inputName = null) {
            return new Variable(true);
        }

    }
}