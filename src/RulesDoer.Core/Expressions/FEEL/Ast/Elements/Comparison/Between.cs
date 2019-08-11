using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison {
    public class Between : IComparisonExpression {
        public readonly IExpression InputValue;
        public readonly IExpression Left;
        public readonly IExpression Right;

        public Between (IExpression value, IExpression left, IExpression right) {
            InputValue = value;
            Left = left;
            Right = right;

        }

        public object Execute (VariableContext context = null) {
            var inputVal = (Variable) InputValue.Execute (context);
            var leftVal = (Variable) Left.Execute (context);
            var rightVal = (Variable) Right.Execute (context);

            var betweenVal = (inputVal >= leftVal && inputVal <= rightVal);

            return new Variable (betweenVal);
        }
    }
}