using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class ManyExpressions : IExpression {
        public List<IExpression> ExpressionLists { get; set; } = new List<IExpression> ();

        public ManyExpressions (List<IExpression> expressionLists) {
            ExpressionLists = expressionLists;
        }
        public object Execute (VariableContext context = null) {

            if (this.ExpressionLists.Count == 1) {
                return this.ExpressionLists[0].Execute ();
            }

            List<Variable> listVal = new List<Variable> ();
            foreach (var expr in this.ExpressionLists) {
                listVal.Add ((Variable) expr.Execute ());
            }

            return new Variable (listVal);
        }
    }
}