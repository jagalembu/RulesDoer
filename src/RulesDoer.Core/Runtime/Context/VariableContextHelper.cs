using RulesDoer.Core.Expressions.FEEL.Eval;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableContextHelper {
        public static Variable RetrieveInputVariable (VariableContext context = null, string inputName = null) {
            context.InputNameDict.TryGetValue (inputName, out var inputVariable);
            if (inputName == null) {
                throw new FEELException ($"Missing input value {inputName}");
            }
            return inputVariable;
        }
    }
}