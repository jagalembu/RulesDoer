using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Boxed {
    public class ContextEntryBoxed : IExpression {
        private readonly IExpression Expression;
        private readonly string KeyLiteral;

        public ContextEntryBoxed (string keyLit, IExpression expression) {
            Expression = expression;            
            KeyLiteral = keyLit.Trim (new Char[] { '"' });;
        }

        public object Execute (VariableContext context = null) {
            return new Variable (KeyLiteral, (Variable) Expression.Execute (context));
        }
    }
}