using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableContextHelper {

        public static bool RetrieveBkm (string bkmName, VariableContext context, out BkmMeta outBkmMeta) {

            if (context == null) {
                outBkmMeta = null;
                return false;
            }

            if (context.BKMMetaByName == null) {
                outBkmMeta = null;
                return false;
            }
            context.BKMMetaByName.TryGetValue (bkmName, out var bkmMeta);
            outBkmMeta = bkmMeta;

            return (bkmMeta == null) ? false : true;
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

            if (context == null) {
                return null;
            }

            if (context.InputNameDict == null) {
                if (doException) {
                    throw new FEELException ($"Missing input data for input name {inputName}");
                }
                return null;
            }
            if (inputName.Contains (".")) {
                var x = inputName.Split ('.');

                context.InputNameDict.TryGetValue (x[0], out var cntxt);
                cntxt.ExpectedDataType (DataTypeEnum.Context);

                Variable contextVal = null;

                for (int i = 1; i < x.Length; i++) {
                    cntxt.ContextInputs.ContextDict.TryGetValue (x[i], out var newVal);
                    if (newVal.ValueType == DataTypeEnum.Context) {
                        cntxt = newVal;
                    }
                    contextVal = newVal;
                }
                return contextVal;
            }
            context.InputNameDict.TryGetValue (inputName, out var inputVariable);
            if (inputVariable == null && doException) {
                throw new FEELException ($"Missing input value {inputName}");
            }
            return inputVariable;
        }

        public static Variable RetrieveGlobalVariable (VariableContext context = null, string inputName = null, bool doException = true) {

            if (context == null) {
                return null;
            }

            if (context.GlobalDict == null) {
                if (doException) {
                    throw new FEELException ($"Missing global data for input name {inputName}");
                }
                return null;
            }

            context.GlobalDict.TryGetValue (inputName, out var inputVariable);
            if (inputVariable == null && doException) {
                throw new FEELException ($"Missing input value {inputName}");
            }
            return inputVariable;
        }

        public static Variable RetrieveLocaContext (VariableContext context = null, string inputName = null, bool doException = true) {
            if (context == null) {
                return null;
            }

            if (context.LocalContext == null) {
                return null;
            }

            context.LocalContext.ContextDict.TryGetValue ("__currentContextX__", out var currCtxt);

            if (inputName.Contains (".")) {
                var x = inputName.Split ('.');

                Variable contextVal = null;
                Variable cntxt = context.LocalContext;

                for (int i = 0; i < x.Length; i++) {
                    cntxt.ContextInputs.ContextDict.TryGetValue (x[i], out var newVal);
                    if (newVal == null && currCtxt != null) {
                        currCtxt.ContextInputs.ContextDict.TryGetValue (x[i], out newVal);
                    }

                    if (newVal.ValueType == DataTypeEnum.Context) {
                        cntxt = newVal;
                    }
                    contextVal = newVal;
                }
                return contextVal;
            }
            context.LocalContext.ContextDict.TryGetValue (inputName, out var ctxVar);
            if (ctxVar == null && currCtxt != null) {
                currCtxt.ContextInputs.ContextDict.TryGetValue (inputName, out ctxVar);
            }
            if (ctxVar == null && doException) {
                throw new FEELException ($"Missing local context value {inputName}");
            }
            return ctxVar;

        }

    }
}