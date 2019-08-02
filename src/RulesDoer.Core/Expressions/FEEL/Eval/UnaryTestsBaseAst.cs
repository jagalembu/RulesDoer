using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class UnaryTestsBaseAst : FEELRuleBaseListener {
        private readonly VariableContext _variableContext;
        private readonly string _inputName;
        public bool Value { get; set; }

        public UnaryTestsBaseAst (VariableContext variableContext, string inputName) {
            _variableContext = variableContext;
            _inputName = inputName;
        }

        public override void ExitUnaryTestsBase (FEELRule.UnaryTestsBaseContext context) {
            var ast = context.ast;

            Value = ((Variable)ast.Execute (_variableContext, _inputName)).BoolVal;
        }

    }
}