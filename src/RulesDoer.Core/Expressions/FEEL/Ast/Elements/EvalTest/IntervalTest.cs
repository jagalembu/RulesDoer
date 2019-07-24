using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class IntervalTest : ITestExpression {
        private readonly string Start;
        private readonly string End;
        private readonly IExpression LeftExpression;
        private readonly IExpression RightExpression;

        public IntervalTest (string start, string end, IExpression leftExpression, IExpression rightExpression) {
            Start = start;
            End = end;
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public bool Execute (VariableContext context = null, string inputName = null) {
            var inputVariable = VariableContextHelper.RetrieveInputVariable (context, inputName);

            var leftVar = (Variable) LeftExpression.Execute (context);
            var rightVar = (Variable) RightExpression.Execute (context);

            if (inputVariable.ValueType != rightVar.ValueType) {
                throw new FEELException ($"Right value {inputVariable.ValueType} and right {rightVar.ValueType} are not the same for comparison");
            }
            if (inputVariable.ValueType != leftVar.ValueType) {
                throw new FEELException ($"Left value {inputVariable.ValueType} and right {leftVar.ValueType} are not the same for comparison");
            }

            if (leftVar > rightVar) {
                throw new FEELException ($"Left value {leftVar} cannot be greater than right value {rightVar}");
            }

            var leftBool = false;
            var rightBool = false;

            //             is in the interval (e1..e2), also notated ]e1..e2[, if and only if o > e1 and o < e1
            //  is in the interval (e1..e2], also notated ]e1..e2], if and only if o > e1 and o ≤ e2
            //  is in the interval [e1..e2] if and only if o ≥ e1 and o ≤ e2
            //  is in the interval [e1..e2), also notated [e1..e2[, if and only if o ≥ e1 and o < e2 

            switch (Start) {
                case "(":
                case "]":
                    leftBool = inputVariable > leftVar;
                    break;
                case "[":
                    leftBool = inputVariable >= leftVar;
                    break;
                default:
                    throw new FEELException ($"Incorrect start {Start} interval character");
            }

            switch (End) {
                case ")":
                case "[":
                    rightBool = inputVariable < rightVar;
                    break;
                case "]":
                    rightBool = inputVariable <= rightVar;
                    break;
                default:
                    throw new FEELException ($"Incorrect end {End} interval character");
            }

            return leftBool && rightBool;
        }

    }
}