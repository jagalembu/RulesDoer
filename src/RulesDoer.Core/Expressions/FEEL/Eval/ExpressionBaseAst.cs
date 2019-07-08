using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class ExpressionBaseAst : FEELRuleBaseListener {
        public Variable Value { get; set; }

        public override void ExitExpressionBase (FEELRule.ExpressionBaseContext context) {
            var ast = context.ast;
            Value = (Variable) ast.Execute ();

        }

    }
}