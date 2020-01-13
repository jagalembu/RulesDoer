using System.Collections.Generic;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableContextExtension {

        public static void AddToInputDict (this VariableContext context, string varName, Variable newVariable) {
            if (!context.InputNameDict.TryAdd (varName, newVariable)) {
                context.InputNameDict[varName] = newVariable;
            }
        }

        public static void AddToInputDict (this VariableContext context, IDictionary<string, Variable> dictVars) {
            foreach (var item in dictVars) {
                context.AddToInputDict (item.Key, item.Value);
            }
        }

        public static void AddToFunctionInputs (this VariableContext context, string varName, Variable newVariable) {
            if (!context.FunctionInputs.TryAdd (varName, newVariable)) {
                context.FunctionInputs[varName] = newVariable;
            }
        }

        public static void AddToFunctionInputs (this VariableContext context, IDictionary<string, Variable> dictVars) {
            foreach (var item in dictVars) {
                context.AddToFunctionInputs (item.Key, item.Value);
            }
        }

    }
}