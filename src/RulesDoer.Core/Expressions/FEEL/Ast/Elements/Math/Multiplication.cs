using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public class Multiplication : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Multiplication () {

        }
        public void Execute (IAstVisitor visitor) {
            visitor.VisitMultiplication (this);
        }
    }
}