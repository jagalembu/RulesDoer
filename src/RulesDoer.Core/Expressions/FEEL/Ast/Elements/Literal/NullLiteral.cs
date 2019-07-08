using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class NullLiteral : IExpression {

        public NullLiteral () { }

        public object Execute (VariableContext context = null) {
            return new Variable ();
        }
    }
}