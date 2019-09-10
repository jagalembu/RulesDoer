using System;
using System.Collections.Generic;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableHelper {

        public static Variable MakeList (List<Variable> lVars, string typeName) {
            switch (typeName.ToLower()) {
                case "string":
                    return Variable.ListType (lVars, DataTypeEnum.ListString);
                case "number":
                    return Variable.ListType (lVars, DataTypeEnum.ListDecimal);
                case "boolean":
                    return Variable.ListType (lVars, DataTypeEnum.ListBoolean);
                case "date":
                case "datetime":
                case "time":
                case "yearmonthduration":
                case "daytimeduration":
                default:
                    return Variable.ListType (lVars, DataTypeEnum.List);
            }

        }

        public static bool IsBaseTypes (string typeName) {
            switch (typeName.ToLower()) {
                case "string":
                case "number":
                case "boolean":
                case "date":
                case "datetime":
                case "time":
                case "yearmonthduration":
                case "daytimeduration":
                    return true;
                default:
                    return false;
            }

        }

        public static Variable MakeVariable (object value, string typeName) {
            if (value == null) {
                return new Variable ();
            }
            switch (typeName.ToLower()) {
                case "string":
                    return value.ToString ();
                case "number":
                    return Decimal.Parse (value.ToString ());
                case "boolean":
                    return bool.Parse (value.ToString ());
                case "date":
                    return DateAndTimeHelper.DateVal (value.ToString ());
                case "datetime":
                    return DateAndTimeHelper.DateTimeVal (value.ToString ());
                case "time":
                    return DateAndTimeHelper.TimeVal (value.ToString ());
                case "yearmonthduration":
                    return DateAndTimeHelper.DurationVal (value.ToString ());
                case "daytimeduration":
                    return DateAndTimeHelper.DurationVal (value.ToString ());
                default:
                    throw new NotImplementedException ($"The following type: {typeName} is not supported for a variable");
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
                    return DateAndTimeHelper.DateVal (value.ToString ());
                case DataTypeEnum.DateTime:
                    return DateAndTimeHelper.DateTimeVal (value.ToString ());
                case DataTypeEnum.Time:
                    return DateAndTimeHelper.TimeVal (value.ToString ());
                case DataTypeEnum.YearMonthDuration:
                case DataTypeEnum.DayTimeDuration:
                case DataTypeEnum.Duration:
                    return DateAndTimeHelper.DurationVal (value.ToString ());
                case DataTypeEnum.Null:
                    return new Variable ();
                default:
                    throw new NotImplementedException ($"The following type: {typeEnum} is not supported for a variable");
            }
        }

    }
}