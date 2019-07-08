using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class Name : IExpression {
        string NameInput;

        public Name (string name) {
            NameInput = name;
        }

        public object Execute (VariableContext context = null) {
            return new Variable (NameInput);
        }
    }
}