using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime.Context {
    public class Variable : IComparable<Variable> {
        public DataTypeEnum ValueType { get; set; }
        public string InputName { get; set; }
        public decimal NumericVal { get; set; }
        public bool BoolVal { get; set; }
        public DateTime DateTimeVal { get; set; }
        public TimeSpan DurationVal { get; set; }
        public string StringVal { get; set; }
        public TimeSpan TimeSpanVal { get; set; }
        public object ObjectVal { get; set; }
        public List<Variable> ListVal { get; set; }
        public (Variable a, Variable b) TwoTuple { get; set; }

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

        public Variable (DataTypeEnum timeType, DateTime inTime) {
            ValueType = timeType;
            DateTimeVal = inTime;
        }

        public Variable (List<Variable> lst) {
            ListVal = lst;
            ValueType = DataTypeEnum.List;
        }

        public Variable (Variable a, Variable b) {
            TwoTuple = (a, b);
            ValueType = DataTypeEnum.Tuple;
        }

        static public Variable Years (int years, int months = 0) {
            return Months (years * 12 + months);
        }

        static public Variable Months (int months) {
            return new Variable (DataTypeEnum.YearMonthDuration, months);
        }

        static public Variable Time (DateTime tm) {
            return new Variable (DataTypeEnum.Time, tm);
        }

        static public Variable Date (DateTime tm) {
            return new Variable (DataTypeEnum.Date, tm);
        }

        public int CompareTo (Variable variable) {
            switch (variable.ValueType) {
                case DataTypeEnum.Boolean:
                    return this.BoolVal.CompareTo (variable.BoolVal);
                case DataTypeEnum.String:
                    return this.StringVal.CompareTo (variable.StringVal);
                case DataTypeEnum.DateTime:
                case DataTypeEnum.Time:
                case DataTypeEnum.Date:
                    return this.DateTimeVal.CompareTo (variable.DateTimeVal);
                case DataTypeEnum.Decimal:
                    return this.NumericVal.CompareTo (variable.NumericVal);
                case DataTypeEnum.DayTimeDuration:
                    return this.TimeSpanVal.CompareTo (variable.TimeSpanVal);
                case DataTypeEnum.YearMonthDuration:
                    return this.NumericVal.CompareTo (variable.NumericVal);

                default:
                    throw new FEELException ($"{variable.ValueType} is not supported for comparisons");

            }
        }

        public override bool Equals (object obj) {
            return this.CompareTo (obj as Variable) == 0;
        }

        public static bool operator > (Variable operand1, Variable operand2) {
            return operand1.CompareTo (operand2) == 1;
        }

        public static bool operator < (Variable operand1, Variable operand2) {
            return operand1.CompareTo (operand2) == -1;
        }

        public static bool operator >= (Variable operand1, Variable operand2) {
            return operand1.CompareTo (operand2) >= 0;
        }

        public static bool operator <= (Variable operand1, Variable operand2) {
            return operand1.CompareTo (operand2) <= 0;
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

        static public implicit operator Variable (List<Variable> lst) {
            return new Variable (lst);
        }

        static public implicit operator bool (Variable ev) {
            if (ev.ValueType != DataTypeEnum.Boolean)
                throw new NotSupportedException ("Expected boolean value.");
            return ev.BoolVal;
        }

        static public implicit operator decimal (Variable ev) {
            if (ev.ValueType != DataTypeEnum.Decimal && ev.ValueType != DataTypeEnum.YearMonthDuration)
                throw new NotSupportedException ("Expected number value.");
            return ev.NumericVal;
        }

        static public implicit operator string (Variable ev) {
            if (ev.ValueType != DataTypeEnum.String)
                throw new NotSupportedException ("Expected string value.");
            return ev.StringVal;
        }

        static public implicit operator DateTime (Variable ev) {
            if (ev.ValueType != DataTypeEnum.DateTime && ev.ValueType != DataTypeEnum.Date && ev.ValueType != DataTypeEnum.Time)
                throw new NotSupportedException ("Expected DateTime value.");
            return ev.DateTimeVal;
        }

        static public implicit operator TimeSpan (Variable ev) {
            if (ev.ValueType != DataTypeEnum.DayTimeDuration)
                throw new NotSupportedException ("Expected Duration value.");
            return ev.TimeSpanVal;
        }

        static public implicit operator List<Variable> (Variable ev) {
            if (ev.ValueType != DataTypeEnum.List)
                throw new NotSupportedException ("Expected List value.");
            return ev.ListVal;
        }

    }
}