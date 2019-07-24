using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison {
    public class Relational : IComparisonExpression {
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }
        public OperatorEnum Operator { get; private set; }

        public Relational (OperatorEnum op, IExpression left, IExpression right) {
            Operator = op;
            Left = left;
            Right = right;
        }
        public object Execute (VariableContext context = null) {
            var leftVar = (Variable) Left.Execute ( context);
            var rightVar = (Variable) Right.Execute ( context);

            if (leftVar.ValueType != rightVar.ValueType) {
                throw new FEELException ($"Left value {leftVar.ValueType} and right {rightVar.ValueType} are not the same for comparison");
            }

            switch (Operator) {
                case OperatorEnum.EQ:
                    return new Variable (leftVar.Equals (rightVar));

                case OperatorEnum.NE:
                    return new Variable (!leftVar.Equals (rightVar));

                case OperatorEnum.GT:
                    return new Variable (leftVar > rightVar);

                case OperatorEnum.GE:
                    return new Variable (leftVar >= rightVar);

                case OperatorEnum.LT:
                    return new Variable (leftVar < rightVar);

                case OperatorEnum.LE:
                    return new Variable (leftVar <= rightVar);

                default:
                    throw new FEELException ("No operator found for comparison");
            }
        }
    }
}