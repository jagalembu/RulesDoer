using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class SimpleUnaryTestsBaseAst : FEELRuleBaseListener {

        private readonly VariableContext _variableContext;
        private readonly string _inputName;
        public bool Value { get; set; }

        public SimpleUnaryTestsBaseAst (VariableContext variableContext, string inputName) {
            _variableContext = variableContext;
            _inputName = inputName;
        }

        public override void ExitSimpleUnaryTestsBase (FEELRule.SimpleUnaryTestsBaseContext context) {
            var ast = context.ast;

            Value = ast.Execute (_variableContext, _inputName);
        }

    }
}