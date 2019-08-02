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
            var exprVal = Expr.Execute (context);

            if (exprVal is Variable exprOut && exprOut.ValueType == DataTypeEnum.String) {

                return exprVal;

            }

            throw new FEELException ("The instance type value is not a string type.");
        }
    }
}