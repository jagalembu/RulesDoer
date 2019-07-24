using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths {
    public class ArithmeticNegation : IExpression {
        public IExpression Right { get; set; }

        public ArithmeticNegation (IExpression right) {

            Right = right;
        }
        public object Execute (VariableContext context = null) {
            var num = this.Right.Execute (context);

            if (num is Variable n) {
                switch (n.ValueType) {
                    case DataTypeEnum.Decimal:
                        return  new Variable (n * -1);

                }
            }

            throw new FEELException ("Failed negation");
        }
    }
}