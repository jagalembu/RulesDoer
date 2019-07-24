using RulesDoer.Core.Expressions.FEEL.Eval;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableContextHelper {
        public static Variable RetrieveInputVariable (VariableContext context = null, string inputName = null, bool doException = true) {
            if (context.InputNameDict == null) {
                if (doException) {
                    throw new FEELException ($"Missing input data for input name {inputName}");
                }
                return null;
            }
            context.InputNameDict.TryGetValue (inputName, out var inputVariable);
            if (inputName == null && doException) {
                throw new FEELException ($"Missing input value {inputName}");
            }
            return inputVariable;
        }

        public static Variable RetrieveGlobalVariable (VariableContext context = null, string inputName = null, bool doException = true) {
            if (context.GlobalDict == null) {
                if (doException) {
                    throw new FEELException ($"Missing global data for input name {inputName}");
                }
                return null;
            }

            context.GlobalDict.TryGetValue (inputName, out var inputVariable);
            if (inputName == null && doException) {
                throw new FEELException ($"Missing input value {inputName}");
            }
            return inputVariable;
        }
    }
}