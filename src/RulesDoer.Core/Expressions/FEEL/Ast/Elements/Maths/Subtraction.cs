using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Subtraction : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Subtraction (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }

        public object Execute (VariableContext context = null) {
            var leftVal = this.Left.Execute (context);
            var rightVal = this.Right.Execute (context);

            if (leftVal is Variable l && rightVal is Variable r) {
                if (l.ValueType != r.ValueType) {
                    throw new FEELException ("The variable type does not match for the arithmetic action");
                }
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return new Variable (l.NumericVal - r.NumericVal);

                    case DataTypeEnum.Date:
                    case DataTypeEnum.DateTime:
                    case DataTypeEnum.Time:
                    case DataTypeEnum.Duration:
                        return DateAndTimeHelper.Subtract (l, r);

                    default:
                        throw new FEELException ("Failed to perform subtraction to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform subtraction due to values not being a variable");

        }
    }
}