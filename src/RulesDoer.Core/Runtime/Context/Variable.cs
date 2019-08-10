using System;
using System.Collections.Generic;
using System.Linq;
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
        public ContextInputs ContextInputs { get; set; }
        public DecisionTableResult DecisionTableResult { get; set; }

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

        public Variable (ContextInputs context) {
            ContextInputs = context;
            ValueType = DataTypeEnum.Context;
        }

        public Variable (DecisionTableResult dtr) {
            DecisionTableResult = dtr;
            ValueType = DataTypeEnum.DecisionTableResult;
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
                case DataTypeEnum.List:
                case DataTypeEnum.Context:
                    return 0;
                default:
                    throw new FEELException ($"The following type {variable.ValueType} is not supported");

            }
        }

        public override bool Equals (object obj) {

            if (this.ValueType == DataTypeEnum.List) {
                return this.ListVal.SequenceEqual (((Variable) obj).ListVal);
            }

            if (this.ValueType == DataTypeEnum.Context) {

                var compareVar = obj as Variable;
                var match = this.ContextInputs.ContextDict.Keys.SequenceEqual (compareVar.ContextInputs.ContextDict.Keys);

                if (match) {
                    foreach (var item in this.ContextInputs.ContextDict.Keys) {
                        this.ContextInputs.ContextDict.TryGetValue (item, out Variable inValVar);

                        if (inValVar is null) {
                            return false;
                        }

                        compareVar.ContextInputs.ContextDict.TryGetValue (item, out Variable compValVar);

                        if (compValVar is null) {
                            return false;
                        }

                        match = inValVar.Equals (compValVar);

                        if (!match) {
                            return false;
                        }

                    }
                    return true;
                }

                return false;
            }

            return this.CompareTo (obj as Variable) == 0;
        }

        public override int GetHashCode () {

            int hashCode = 0;
            switch (this.ValueType) {
                case DataTypeEnum.Boolean:
                    hashCode = this.BoolVal.GetHashCode ();
                    break;
                case DataTypeEnum.String:
                    hashCode = this.StringVal.GetHashCode ();
                    break;
                case DataTypeEnum.DateTime:
                case DataTypeEnum.Time:
                case DataTypeEnum.Date:
                    hashCode = this.DateTimeVal.GetHashCode ();
                    break;
                case DataTypeEnum.Decimal:
                    hashCode = this.NumericVal.GetHashCode ();
                    break;
                case DataTypeEnum.DayTimeDuration:
                    hashCode = this.TimeSpanVal.GetHashCode ();
                    break;
                case DataTypeEnum.YearMonthDuration:
                    hashCode = this.NumericVal.GetHashCode ();
                    break;
            }
            return hashCode;
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

        static public implicit operator Variable (ContextInputs context) {
            return new Variable (context);
        }

        static public implicit operator Variable (DecisionTableResult dtr) {
            return new Variable (dtr);
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

        static public implicit operator ContextInputs (Variable ev) {
            if (ev.ValueType != DataTypeEnum.Context)
                throw new NotSupportedException ("Expected Context value.");
            return ev.ContextInputs;
        }

        static public implicit operator DecisionTableResult (Variable ev) {
            if (ev.ValueType != DataTypeEnum.DecisionTableResult)
                throw new NotSupportedException ("Expected Decision Table Result value.");
            return ev.DecisionTableResult;
        }

    }
}