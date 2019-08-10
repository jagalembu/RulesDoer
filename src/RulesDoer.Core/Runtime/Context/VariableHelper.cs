using System;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableHelper {
        public static Variable MakeVariable (object value, string typename) {
            if (value == null) {
                return new Variable ();
            }
            switch (typename) {
                case "string":
                    return value.ToString ();
                case "number":
                    return Decimal.Parse (value.ToString ());
                case "boolean":
                    return bool.Parse (value.ToString ());
                case "date":
                    return Variable.Date (DateTime.Parse (value.ToString ()));
                case "datetime":
                    return DateTime.Parse (value.ToString ());
                case "time":
                    return Variable.Time (DateTime.Parse (value.ToString ()));
                case "yearMonthDuration":
                    return DurationHelper.MakeYearMonth (value.ToString ());
                case "dayTimeDuration":
                    return DurationHelper.MakeDayTime (value.ToString ());
                default:
                    throw new NotImplementedException ($"The following type: {typename} is not supported for a variable");
            }
        }

        public static Variable MakeVariable (object value, DataTypeEnum typeEnum) {
            if (value == null) {
                return new Variable ();
            }
            switch (typeEnum) {
                case DataTypeEnum.String:
                    return value.ToString ();
                case DataTypeEnum.Decimal:
                    return Decimal.Parse (value.ToString ());
                case DataTypeEnum.Boolean:
                    return bool.Parse (value.ToString ());
                case DataTypeEnum.Date:
                    return Variable.Date (DateTime.Parse (value.ToString ()));
                case DataTypeEnum.DateTime:
                    return DateTime.Parse (value.ToString ());
                case DataTypeEnum.Time:
                    return Variable.Time (DateTime.Parse (value.ToString ()));
                case DataTypeEnum.YearMonthDuration:
                    return DurationHelper.MakeYearMonth (value.ToString ());
                case DataTypeEnum.DayTimeDuration:
                    return DurationHelper.MakeDayTime (value.ToString ());
                case DataTypeEnum.Null:
                    return new Variable();    
                default:
                    throw new NotImplementedException ($"The following type: {typeEnum} is not supported for a variable");
            }
        }
    }
}