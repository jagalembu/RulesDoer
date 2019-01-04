using System;
using System.Globalization;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Types {
    public class TypesTransformerHelper {

        public DataTypeEnum DetermineEnum (string dataType) {

            switch (dataType.ToLower ()) {
                case "string":
                    return DataTypeEnum.String;
                case "boolean":
                    return DataTypeEnum.Boolean;
                case "date":
                    return DataTypeEnum.Date;
                case "datetime":
                    return DataTypeEnum.DateTime;
                case "datetimestamp":
                    return DataTypeEnum.DateTimestamp;
                case "time":
                    return DataTypeEnum.Time;
                case "daytimeduration":
                    return DataTypeEnum.DayTimeDuration;
                case "yearmonthduration":
                    return DataTypeEnum.YearMonthDuration;
                case "double":
                    return DataTypeEnum.Double;
                case "decimal":
                    return DataTypeEnum.Decimal;
                case "integer":
                    return DataTypeEnum.Integer;

                default:
                    throw new Exception ($"Data Type {dataType} is not handled");
            }

        }

        public Variable TransformToVariable (string val, string inputType, string inputName = null) {

            var dataTypeEnum = DetermineEnum (inputType);

            switch (dataTypeEnum) {
                case DataTypeEnum.Boolean:
                    return new Variable { InputName = inputName, BoolVal = bool.Parse (val), ValueType = dataTypeEnum };
                case DataTypeEnum.String:
                    return new Variable { InputName = inputName, StringVal = val, ValueType = dataTypeEnum };
                case DataTypeEnum.Date:
                    return new Variable { InputName = inputName, DateTimeVal = DateTime.ParseExact (val, "d", CultureInfo.InvariantCulture), ValueType = dataTypeEnum };
                case DataTypeEnum.DateTime:
                    return new Variable { InputName = inputName, DateTimeVal = DateTime.ParseExact (val, "d", CultureInfo.InvariantCulture), ValueType = dataTypeEnum };
                case DataTypeEnum.DateTimestamp:
                    return new Variable { InputName = inputName, DateTimeVal = DateTime.ParseExact (val, "d", CultureInfo.InvariantCulture), ValueType = dataTypeEnum };
                case DataTypeEnum.Time:
                    return new Variable { InputName = inputName, DateTimeVal = DateTime.ParseExact (val, "d", CultureInfo.InvariantCulture), ValueType = dataTypeEnum };
                case DataTypeEnum.YearMonthDuration: // need to translate durations
                    return new Variable { InputName = inputName, TimeSpanVal = TimeSpan.Parse (val), ValueType = dataTypeEnum };
                case DataTypeEnum.DayTimeDuration: // need to translate durations
                    return new Variable { InputName = inputName, TimeSpanVal = TimeSpan.Parse (val), ValueType = dataTypeEnum };
                case DataTypeEnum.Decimal:
                    return new Variable { InputName = inputName, NumericVal = decimal.Parse (val), ValueType = dataTypeEnum };
                case DataTypeEnum.Double:
                    return new Variable { InputName = inputName, NumericVal = decimal.Parse (val), ValueType = dataTypeEnum };
                case DataTypeEnum.Integer:
                    return new Variable { InputName = inputName, NumericVal = decimal.Parse (val), ValueType = dataTypeEnum };

                default:
                    throw new NotSupportedException ($"Data Type {inputType} is not handled");
            }
        }

    }
}