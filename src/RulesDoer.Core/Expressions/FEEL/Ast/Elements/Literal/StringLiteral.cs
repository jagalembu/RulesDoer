using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class StringLiteral : IExpression {
        public Variable Value { get; private set; }

        public StringLiteral (string expression) {
            var stringLit = expression.Trim (new Char[] { '"' });
            Value = new Variable (stringLit);
        }

        public object Execute (VariableContext context = null) {
            return this.Value;
        }
    }
}