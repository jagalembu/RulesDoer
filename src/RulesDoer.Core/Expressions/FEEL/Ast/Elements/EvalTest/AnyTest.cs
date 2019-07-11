using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class AnyTest : ITestExpression {
        public bool Execute (VariableContext context = null, string inputName = null) {
            return true;
        }

    }
}