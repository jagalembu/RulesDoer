using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableExtension {
        public static void ExpectedDataType (this Variable variable, DataTypeEnum datatype) {
            if (variable.ValueType != datatype) {
                throw new FEELException ($"Expected data type: {datatype} but is: {variable.ValueType}");
            }
        }

        public static bool IsListType (this Variable variable) {
            switch (variable.ValueType) {
                case DataTypeEnum.List:
                case DataTypeEnum.ListBoolean:
                case DataTypeEnum.ListDecimal:
                case DataTypeEnum.ListString:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsDurationType (this Variable variable) {
            switch (variable.ValueType) {
                case DataTypeEnum.YearMonthDuration:
                case DataTypeEnum.DayTimeDuration:
                    return true;
                default:
                    return false;
            }
        }

        public static bool ListWithSingleTypedVariable (this Variable variable) {
            switch (variable.ValueType) {
                case DataTypeEnum.ListBoolean:
                case DataTypeEnum.ListDecimal:
                case DataTypeEnum.ListString:
                    return true;
                default:
                    return false;
            }
        }
    }
}