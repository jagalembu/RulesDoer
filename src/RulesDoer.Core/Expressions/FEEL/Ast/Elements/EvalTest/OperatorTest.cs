using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class OperatorTest : ITestExpression {

        public IExpression Right { get; private set; }
        public OperatorEnum Operator { get; private set; }

        public OperatorTest (OperatorEnum op, IExpression right) {
            Operator = op;
            Right = right;
        }

        public bool Execute (VariableContext context = null, string inputName = null) {

            var inputVariable = VariableContextHelper.RetrieveInputVariable (context, inputName);

            var rightVar = (Variable) Right.Execute (context);

            if (inputVariable.ValueType != rightVar.ValueType) {
                throw new FEELException ($"Left value {inputVariable.ValueType} and right {rightVar.ValueType} are not the same for comparison");
            }

            switch (Operator) {

                case OperatorEnum.GT:
                    return inputVariable > rightVar;

                case OperatorEnum.GE:
                    return inputVariable >= rightVar;

                case OperatorEnum.LT:
                    return inputVariable < rightVar;

                case OperatorEnum.LE:
                    return inputVariable <= rightVar;

                case OperatorEnum.NF:
                    return inputVariable.Equals (rightVar);

                default:
                    throw new FEELException ($"The following operator {Operator} is not supported");
            }

        }

    }
}