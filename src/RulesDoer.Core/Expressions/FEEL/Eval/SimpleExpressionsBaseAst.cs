using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class SimpleExpressionsBaseAst : FEELRuleBaseListener {

        public Variable Value { get; set; }
        public override void ExitSimpleExpressionsBase (FEELRule.SimpleExpressionsBaseContext context) {
            var ast = context.ast;

            Value = (Variable) ast.Execute ();

        }

    }
}