using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Division : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Division (IExpression left, IExpression right) {
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
                        //return new Variable (Math.Round(l.NumericVal / r.NumericVal, 11, MidpointRounding.ToEven));
                        return new Variable (l.NumericVal / r.NumericVal);

                    default:
                        throw new FEELException ("Failed to perform division to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform division due to values not being a variable");
        }
    }
}