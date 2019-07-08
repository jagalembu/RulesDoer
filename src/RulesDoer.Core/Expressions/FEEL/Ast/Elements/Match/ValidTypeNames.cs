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
        public const string YearsAndMonthDurationType = "years and month duration";
        public const string DaysAndTimeDurationType = "days and time duration";
        public const string ContextType = "context";
        public const string FunctionType = "function";
        public const string NullType = "null";
        public static Dictionary<string, DataTypeEnum> StringTypeToEnum = new Dictionary<string, DataTypeEnum> () { { ValidTypeNames.AnyType, DataTypeEnum.Any }, { ValidTypeNames.NumberType, DataTypeEnum.Decimal }, { ValidTypeNames.StringType, DataTypeEnum.String }, { ValidTypeNames.BooleanType, DataTypeEnum.Boolean }, { ValidTypeNames.DateType, DataTypeEnum.Date }, { ValidTypeNames.DateTimeType, DataTypeEnum.DateTime }, { ValidTypeNames.ListType, DataTypeEnum.List }, { ValidTypeNames.YearsAndMonthDurationType, DataTypeEnum.YearMonthDuration }, { ValidTypeNames.DaysAndTimeDurationType, DataTypeEnum.DayTimeDuration }, { ValidTypeNames.ContextType, DataTypeEnum.Context }, { ValidTypeNames.FunctionType, DataTypeEnum.Function }, { ValidTypeNames.NullType, DataTypeEnum.Null }
        };

    }
}