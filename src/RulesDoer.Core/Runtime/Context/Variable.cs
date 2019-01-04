using System;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime.Context {
    public class Variable {
        public DataTypeEnum ValueType { get; set; }
        public string InputName { get; set; }
        public decimal NumericVal { get; set; }
        public bool BoolVal { get; set; }
        public DateTime DateTimeVal { get; set; }
        public TimeSpan DurationVal { get; set; }
        public string StringVal { get; set; }
        public TimeSpan TimeSpanVal { get; set; }
        public object ObjectVal { get; set; }

        public Variable () {
            ValueType = DataTypeEnum.Null;
        }
        public Variable (decimal number) {
            NumericVal = number;
            ValueType = DataTypeEnum.Decimal;
        }

        public Variable (bool boolean) {
            BoolVal = boolean;
            ValueType = DataTypeEnum.Boolean;
        }

        public Variable (string str) {
            StringVal = str;
            ValueType = DataTypeEnum.String;
        }

        public Variable (DateTime dt) {
            DateTimeVal = dt;
            ValueType = DataTypeEnum.DateTime;
        }

        public Variable (TimeSpan ts) {
            TimeSpanVal = ts;
            ValueType = DataTypeEnum.DayTimeDuration;
        }

        public Variable (DataTypeEnum yrMnthDurationType, int months) {
            ValueType = yrMnthDurationType;
            NumericVal = months;
        }

        static public Variable Years (int years, int months = 0) {
            return Months (years * 12 + months);
        }

        static public Variable Months (int months) {
            return new Variable (DataTypeEnum.YearMonthDuration, months);
        }

        static public implicit operator Variable (decimal d) {
            return new Variable (d);
        }

        static public implicit operator Variable (bool b) {
            return new Variable (b);
        }

        static public implicit operator Variable (string s) {
            return new Variable (s);
        }

        static public implicit operator Variable (DateTime dt) {
            return new Variable (dt);
        }

        static public implicit operator Variable (TimeSpan ts) {
            return new Variable (ts);
        }

        static public implicit operator bool (Variable ev) {
            if (ev.ValueType != DataTypeEnum.Boolean)
                throw new NotSupportedException ("Expected boolean value.");
            return ev.BoolVal;
        }

        static public implicit operator decimal (Variable ev) {
            if (ev.ValueType != DataTypeEnum.Decimal)
                throw new NotSupportedException ("Expected number value.");
            return ev.NumericVal;
        }

        static public implicit operator string (Variable ev) {
            if (ev.ValueType != DataTypeEnum.String)
                throw new NotSupportedException ("Expected string value.");
            return ev.StringVal;
        }

        static public implicit operator DateTime (Variable ev) {
            if (ev.ValueType != DataTypeEnum.DateTime)
                throw new NotSupportedException ("Expected DateTime value.");
            return ev.DateTimeVal;
        }

        static public implicit operator TimeSpan (Variable ev) {
            if (ev.ValueType != DataTypeEnum.DayTimeDuration)
                throw new NotSupportedException ("Expected Duration value.");
            return ev.TimeSpanVal;
        }

    }
}