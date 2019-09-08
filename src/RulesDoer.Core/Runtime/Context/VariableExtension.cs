using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableExtension {
        public static void ExpectedDataType (this Variable variable, DataTypeEnum datatype) {
            if (variable.ValueType != datatype) {
                throw new FEELException ($"Expected data type: {datatype} but is: {variable.ValueType}");
            }
        }
    }
}