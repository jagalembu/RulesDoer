using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Statement {
    public class IfStatement : IExpression {
        private readonly IExpression Condition;
        private readonly IExpression ThenExpr;
        private readonly IExpression ElseExpr;

        public IfStatement (IExpression cond, IExpression first, IExpression second) {
            Condition = cond;
            ThenExpr = first;
            ElseExpr = second;
        }
        
        public object Execute (VariableContext context = null) {
            var condRslt = (Variable) Condition.Execute (context);

            if (condRslt.BoolVal && condRslt.ValueType == DataTypeEnum.Boolean) {
                return (Variable) ThenExpr.Execute (context);
            }
            return (Variable) ElseExpr.Execute (context);
        }
    }
}