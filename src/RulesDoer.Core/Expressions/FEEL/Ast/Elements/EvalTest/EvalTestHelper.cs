using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public static class EvalTestHelper {
        public static Variable ExecuteBasedOnType (IEle expression, VariableContext context, string inputDataName) {
            switch (expression) {
                case TestWrapper wrapper:
                    wrapper.InputDataName = inputDataName;
                    return (Variable) wrapper.Execute (context);

                case ITestExpression testExpression:
                    return (Variable)testExpression.Execute (context, inputDataName);

                default:
                    throw new DMNException ($"Invalid type of expression.");
            }
        }
    }
}