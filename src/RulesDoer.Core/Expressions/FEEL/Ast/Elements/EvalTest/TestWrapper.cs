using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class TestWrapper : IExpression {
        private readonly IEle Expression;
        public string InputDataName { get; set; }

        public TestWrapper (IEle expression) {
            Expression = expression;
        }

        public object Execute (VariableContext context = null) {
            switch (Expression) {
                case ITestExpression testExpression:
                    return testExpression.Execute (context, InputDataName);

                case IExpression normExpression:
                    return normExpression.Execute (context);

                default:
                    throw new FEELException ("Not supported expression type");
            }

        }
    }
}