using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public class Exponentiation : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Exponentiation () {

        }
        public void Execute (IAstVisitor visitor) {
            visitor.Visit (this);
        }
    }
}