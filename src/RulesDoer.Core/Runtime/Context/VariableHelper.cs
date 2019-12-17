using System;
using System.Collections.Generic;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Runtime.Context {
    public static class VariableHelper {

        public static Variable MakeList (List<Variable> lVars, string typeName) {
            switch (typeName.ToLower ()) {
                case "string":
                    return Variable.ListType (lVars, DataTypeEnum.ListString);
                case "number":
                case "decimal":
                case "double":
                    return Variable.ListType (lVars, DataTypeEnum.ListDecimal);
                case "boolean":
                    return Variable.ListType (lVars, DataTypeEnum.ListBoolean);
                case "date":
                case "datetime":
                case "dateTime":
                case "time":
                case "yearmonthduration":
                case "daytimeduration":
                case "duration":
                default:
                    return Variable.ListType (lVars, DataTypeEnum.List);
            }

        }

        public static bool IsBaseTypes (string typeName) {
            switch (typeName.ToLower ()) {
                case "string":
                case "number":
                case "decimal":
                case "double":
                case "boolean":
                case "date":
                case "datetime":
                case "dateTime":
                case "time":
                case "yearmonthduration":
                case "daytimeduration":
                case "duration":
                    return true;
                default:
                    return false;
            }

        }

        public static Variable MakeVariable (object value, string typeName) {
            if (value == null) {
                return new Variable ();
            }
            switch (typeName.ToLower ()) {
                case "string":
                    return value.ToString ();
                case "number":
                case "decimal":
                case "double":
                    return Decimal.Parse (value.ToString ());
                case "boolean":
                    return bool.Parse (value.ToString ());
                case "date":
                    return DateAndTimeHelper.DateVal (value.ToString ());
                case "dateTime":
                case "datetime":
                    return DateAndTimeHelper.DateTimeVal (value.ToString ());
                case "time":
                    return DateAndTimeHelper.TimeVal (value.ToString ());
                case "yearmonthduration":
                case "daytimeduration":
                case "duration":
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
                    return DateAndTimeHelper.DurationVal (value.ToString ());
                case DataTypeEnum.Null:
                    return new Variable ();
                default:
                    throw new NotImplementedException ($"The following type: {typeEnum} is not supported for a variable");
            }
        }

    }
}