using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Addition : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Addition (IExpression left, IExpression right) {
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
                        return new Variable (l.NumericVal + r.NumericVal);

                    case DataTypeEnum.String:
                        return new Variable ($"{l.StringVal}{r.StringVal}");

                    default:
                        throw new FEELException ("Failed to perform addition to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform addition due to values not being a variable");
        }
    }
}