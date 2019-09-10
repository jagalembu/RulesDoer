using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class Exponentiation : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Exponentiation (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }
        public object Execute (VariableContext context = null) {
            var leftVal = (Variable) Left.Execute (context);
            var rightVal = (Variable) Right.Execute (context);

            if (leftVal is Variable l && rightVal is Variable r) {
                if (l.ValueType != r.ValueType) {
                    throw new FEELException ("The variable type does not match for the arithmetic action");
                }
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:

                        r.ExpectedDataType (DataTypeEnum.Decimal);

                        return MathHelper.Pow (l, r);

                        // var x = Decimal.Parse (rightVal.NumericVal.ToString ());
                        // Decimal powV = 1;
                        // if (x < 0) {
                        //     x = x * -1;
                        // }

                        // for (; x > 0; x--) {
                        //     powV *= leftVal.NumericVal;
                        // }
                        // if (rightVal.NumericVal < 0) {
                        //     powV = 1 / powV;
                        // }
                        // return new Variable (powV);

                    default:
                        throw new FEELException ("Failed to perform exponentiation to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform exponentiation due to values not being a variable");

        }
    }
}