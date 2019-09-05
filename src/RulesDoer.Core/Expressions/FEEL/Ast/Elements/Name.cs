using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class Name : IExpression {
        string NameInput;

        public Name (string name) {
            NameInput = name;
        }

        public object Execute (VariableContext context = null) {
            if (context != null) {
                var outVar = VariableContextHelper.RetrieveInputVariable (context, NameInput, false);
                if (outVar != null) {
                    return outVar;
                }
                var decisionVar = DMNDoerHelper.EvaluateDecisionByName(context, NameInput);
                if (decisionVar != null)
                {
                    return decisionVar;
                }
            }

            return new Variable (NameInput);
        }
    }
}