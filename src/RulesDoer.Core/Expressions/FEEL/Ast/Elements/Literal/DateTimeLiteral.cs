using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class DateTimeLiteral : IExpression {
        public Variable Value { get; private set; }

        public DateTimeLiteral (string dateFunction, string expression) {
            
        }

        public void Execute (IAstVisitor visitor) {
            visitor.VisitDateTimeLiteral(this);
        }
    }
}