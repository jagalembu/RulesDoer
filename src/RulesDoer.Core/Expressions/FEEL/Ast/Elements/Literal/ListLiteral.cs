using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class ListLiteral : IExpression {

        private readonly List<IExpression> Expressions;

        public ListLiteral (List<IExpression> expressions) {
            Expressions = expressions;
        }

        public object Execute (VariableContext context = null) {
            List<Variable> varList = new List<Variable> ();

            foreach (var item in Expressions) {
                varList.Add ((Variable) item.Execute ());
            }

            return new Variable (varList);
        }
    }
}