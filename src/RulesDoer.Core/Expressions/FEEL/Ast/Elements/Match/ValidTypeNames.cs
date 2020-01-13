using System.Collections.Generic;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Match {
    public class ValidTypeNames {
        public const string AnyType = "Any";
        public const string StringType = "string";
        public const string NumberType = "number";
        public const string BooleanType = "boolean";
        public const string DateType = "date";
        public const string TimeType = "time";
        public const string DateTimeType = "date and time";
        public const string ListType = "list";
        public const string YearsAndMonthDurationType = "years and months duration";
        public const string DaysAndTimeDurationType = "days and time duration";
        public const string ContextType = "context";
        public const string FunctionType = "function";
        public const string NullType = "null";
        public static Dictionary<string, DataTypeEnum> StringTypeToEnum =
            new Dictionary<string, DataTypeEnum> () {
                {
                AnyType,
                DataTypeEnum.Any
                }, {
                NumberType,
                DataTypeEnum.Decimal
                }, {
                StringType,
                DataTypeEnum.String
                }, {
                BooleanType,
                DataTypeEnum.Boolean
                }, {
                DateType,
                DataTypeEnum.Date
                }, {                
                TimeType,
                DataTypeEnum.Time
                }, {                    
                DateTimeType,
                DataTypeEnum.DateTime
                }, {
                ListType,
                DataTypeEnum.List
                }, {
                YearsAndMonthDurationType,
                DataTypeEnum.YearMonthDuration
                }, {
                DaysAndTimeDurationType,
                DataTypeEnum.DayTimeDuration
                }, {
                ContextType,
                DataTypeEnum.Context
                }, {
                FunctionType,
                DataTypeEnum.Function
                }, {
                NullType,
                DataTypeEnum.Null
                }
            };

    }
}