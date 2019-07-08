using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Exponentiation : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Exponentiation (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }
        public object Execute (VariableContext context = null) {
            var leftVal = this.Left.Execute ();
            var rightVal = this.Right.Execute ();

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        var leftDbl = (double) leftVal;
                        var rightDbl = (double) rightVal;
                        var rslt = Math.Pow (leftDbl, rightDbl);
                        return new Variable (new decimal (rslt));

                    default:
                        throw new FEELException ("Failed to perform exponentiation to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform exponentiation due to values not being a variable");

        }
    }
}