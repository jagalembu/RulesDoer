using RulesDoer.Core.Expressions.FEEL.Eval;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableContextHelper {

        public static bool RetrieveBkm (string bkmName, VariableContext context, out BkmMeta outBkmMeta) {
            context.BKMMetaByName.TryGetValue (bkmName, out var bkmMeta);
            outBkmMeta = bkmMeta;

            return (bkmMeta == null)? false : true;
        }

        public static VariableContext MakeACopy (VariableContext context) {
            return new VariableContext () {
                BKMMetaByName = context.BKMMetaByName,
                    InputDataMetaById = context.InputDataMetaById,
                    InputDataMetaByName = context.InputDataMetaByName,
                    ItemDefinitionMeta = context.ItemDefinitionMeta
            };
        }

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