using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public class Subtraction : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Subtraction () {

        }
        public void Execute (IAstVisitor visitor) {
            visitor.VisitSubtraction (this);
        }
    }
}