using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class ExpressionBaseAst : FEELRuleBaseListener {
        private readonly VariableContext _variableContext;
        public Variable Value { get; set; }

        public ExpressionBaseAst (VariableContext variableContext) {
            _variableContext = variableContext;
        }
        public override void ExitExpressionBase (FEELRule.ExpressionBaseContext context) {
            var ast = context.ast;
            Value = (Variable) ast.Execute (_variableContext);

        }

    }
}