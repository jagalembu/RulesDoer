using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class PositiveUnaryTest : ITestExpression {
        private readonly IEle Expression;

        public PositiveUnaryTest (IEle expression) {
            Expression = expression;
        }

        public bool Execute (VariableContext context = null, string inputName = null) {

            if (Expression is IExpression expr) {
                var exprVar = (Variable) expr.Execute (context);

                var inputVariable = VariableContextHelper.RetrieveInputVariable (context, inputName);

                if (inputVariable.ValueType != exprVar.ValueType) {
                    throw new FEELException ($"Left value {inputVariable.ValueType} and right {exprVar.ValueType} are not the same for comparison");
                }

                return inputVariable.Equals (exprVar);
            }

            if (Expression is ITestExpression texpr) {
                return texpr.Execute (context, inputName);
            }

            throw new FEELException ("Unexepected type of expression for positive unary test");

        }
    }
}