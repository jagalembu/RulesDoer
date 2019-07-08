using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Multiplication : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Multiplication (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }

        public object Execute (VariableContext context = null) {
            var leftVal = this.Left.Execute ();
            var rightVal = this.Right.Execute ();

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return  new Variable (l.NumericVal * r.NumericVal);

                    default:
                        throw new FEELException ("Failed to perform multiplication to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform multiplication due to values not being a variable");

        }
    }
}