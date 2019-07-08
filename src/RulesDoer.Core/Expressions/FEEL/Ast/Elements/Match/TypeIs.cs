using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Match {
    public class TypeIs : IExpression {

        IExpression Expr;

        public TypeIs (IExpression expr) {
            Expr = expr;
        }

        public object Execute (VariableContext context = null) {
            var exprVal = Expr.Execute ();

            if (exprVal is List<string> outExprVal && outExprVal.Count == 1) {

                return new Variable (outExprVal[0]);

            }

            throw new FEELException ("The expression does not return a list of one string value");
        }
    }
}