using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class SimpleExpressionsBaseAst : FEELRuleBaseListener {
        private readonly VariableContext _variableContext;
        public Variable Value { get; set; }

        public SimpleExpressionsBaseAst (VariableContext variableContext) {
            _variableContext = variableContext;
        }

        public override void ExitSimpleExpressionsBase (FEELRule.SimpleExpressionsBaseContext context) {
            var ast = context.ast;

            Value = (Variable) ast.Execute ();

        }

    }
}