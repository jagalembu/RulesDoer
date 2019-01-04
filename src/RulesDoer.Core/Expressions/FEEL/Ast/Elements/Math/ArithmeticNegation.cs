using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public class ArithmeticNegation : IExpression {
        public IExpression Right { get; set; }

        public ArithmeticNegation () {

        }
        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}