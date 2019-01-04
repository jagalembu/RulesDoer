using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public class Division : IMathExpression {
        public IExpression Left { get; set; }
        public IExpression Right { get; set; }

        public Division () {

        }
        public void Execute (IAstVisitor visitor) {
            visitor.VisitDivision (this);
        }
    }
}