using NodaTime;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Utils {
    public static partial class DateAndTimeHelper {

        public static Variable Addition (Variable left, Variable right) {

            // years and months duration
            // date and time
            // Subtraction is undefined. Addition is commutative and is defined by the previous rule.
            // date and time
            if (left.ValueType == DataTypeEnum.YearMonthDuration && right.ValueType == DataTypeEnum.DateTime) {

                if (right.DateTimeVal.HasValue) {
                    return right.DateTimeVal.Value + left.DurationVal.ToDuration ();
                }

                if (right.LocalDateTimeVal.HasValue) {
                    return right.LocalDateTimeVal.Value + left.DurationVal;
                }

                if (right.ZoneDateTimeVal.HasValue) {
                    return right.ZoneDateTimeVal.Value + left.DurationVal.ToDuration ();
                }

            }

            // days and time duration
            // date and time
            // Subtraction is undefined. Addition is commutative and is defined by the previous rule.
            // date and time
            if (left.ValueType == DataTypeEnum.DayTimeDuration && right.ValueType == DataTypeEnum.DateTime) {
                if (right.DateTimeVal.HasValue) {
                    return right.DateTimeVal.Value + left.DurationVal.ToDuration ();
                }

                if (right.LocalDateTimeVal.HasValue) {
                    return right.LocalDateTimeVal.Value + left.DurationVal;
                }

                if (right.ZoneDateTimeVal.HasValue) {
                    return right.ZoneDateTimeVal.Value + left.DurationVal.ToDuration ();
                }

            }

            // days and time duration
            // time
            // Subtraction is undefined. Addition is commutative and is defined by the previous rule.
            // time
            if (left.ValueType == DataTypeEnum.DayTimeDuration && right.ValueType == DataTypeEnum.Time) {

                if (right.TimeVal.HasValue) {
                    right.TimeVal.Value.Deconstruct (out var lt, out var of );
                    return new OffsetTime (lt + left.DurationVal, of );
                }

                if (right.LocalTimeVal.HasValue) {
                    return right.LocalTimeVal.Value + left.DurationVal;
                }

                if (right.ZoneDateTimeVal.HasValue) {
                    return Variable.Time (right.ZoneDateTimeVal.Value + left.DurationVal.ToDuration ());
                }

            }

            // years and months duration
            // date
            // Subtraction is undefined. Addition is commutative and is defined by the previous rule.
            // date
            if (left.ValueType == DataTypeEnum.YearMonthDuration && right.ValueType == DataTypeEnum.Date) {
                return right.DateVal + left.DurationVal;
            }

            // days and time duration
            // date
            // Subtraction is undefined. Addition is commutative and is defined by the previous rule.
            // date
            if (left.ValueType == DataTypeEnum.DayTimeDuration && right.ValueType == DataTypeEnum.Date) {
                return right.DateVal + left.DurationVal;
            }

            // years and months duration
            // years and months duration
            // valueymd-1(valueymd(e1) +/- valueymd(e2)) where valueymd and valueymd-1 is defined in
            // 10.3.2.3.8.
            // years and months duration
            if (left.ValueType == DataTypeEnum.YearMonthDuration && right.ValueType == DataTypeEnum.YearMonthDuration) {

                return left.DurationVal + right.DurationVal;

            }

            // days and time duration
            // days and time duration
            // valuedtd-1(valuedtd(e1) +/- valuedtd(e2)) where valuedtd and valuedtd-1 is defined in 
            // 10.3.2.3.7
            // days and time duration
            if (left.ValueType == DataTypeEnum.DayTimeDuration && right.ValueType == DataTypeEnum.DayTimeDuration) {
                return left.DurationVal + right.DurationVal;
            }

            // date and time
            // years and months duration
            // date and time (date(e1.year +/– e2.years + floor((e1.month +/– e2.months)/12),
            // e1.month +/– e2.months – floor((e1.month +/– e2.months)/12) * 12, e1.day), time(e1)),
            // where the named properties are as defined in Table 60 below, and the date, date and time, 
            // time and floor functions are as defined in 10.3.4, 
            // valuedt and valuedt-1 is defined in 10.3.2.3.5 and valueymd is defined in 10.3.2.3.8.
            // date and time
            if (left.ValueType == DataTypeEnum.DateTime && right.ValueType == DataTypeEnum.YearMonthDuration) {

                if (left.DateTimeVal.HasValue) {
                    left.DateTimeVal.Value.Deconstruct (out var ldt, out var of );
                    return new OffsetDateTime (ldt + right.DurationVal, of );
                }

                if (left.LocalDateTimeVal.HasValue) {
                    return left.LocalDateTimeVal.Value + right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return left.ZoneDateTimeVal.Value + right.DurationVal.ToDuration ();
                }

            }

            // date and time
            // days and time duration
            // valuedt-1(valuedt(e1) +/- valuedtd(e2)) where valuedt and valuedt-1 is defined in 10.3.2.3.5 
            // and valuedtd is defined in 10.3.2.3.7.
            // date and time
            if (left.ValueType == DataTypeEnum.DateTime && right.ValueType == DataTypeEnum.DayTimeDuration) {

                if (left.DateTimeVal.HasValue) {
                    left.DateTimeVal.Value.Deconstruct (out var ldt, out var of );
                    return new OffsetDateTime (ldt + right.DurationVal, of );
                }

                if (left.LocalDateTimeVal.HasValue) {
                    return left.LocalDateTimeVal.Value + right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return left.ZoneDateTimeVal.Value + right.DurationVal.ToDuration ();
                }

            }

            // time
            // days and time duration
            // valuet-1(valuet(e1) +/- valuedtd(e2)) where valuet and valuet-1 are defined in 10.3.2.3.4 
            // and valuedtd is defined in 10.3.2.3.7.
            // time
            if (left.ValueType == DataTypeEnum.Time && right.ValueType == DataTypeEnum.DayTimeDuration) {

                if (left.TimeVal.HasValue) {
                    left.TimeVal.Value.Deconstruct (out var lt, out var of );
                    return new OffsetTime (lt + right.DurationVal, of );
                }

                if (left.LocalTimeVal.HasValue) {
                    return left.LocalTimeVal.Value + right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return Variable.Time (left.ZoneDateTimeVal.Value + right.DurationVal.ToDuration ());
                }

            }

            // date
            // years and months duration
            // date( e1.year +/– e2.years + floor((e1.month +/– e2.months)/12), e1.month +/– e2.months – floor((e1.month +/– e2.months)/12) * 12, e1.day ), 
            // where the named properties are as defined in Table 60 below, and the date and floor functions 
            // are as defined in 10.3.4
            // date
            if (left.ValueType == DataTypeEnum.Date && right.ValueType == DataTypeEnum.YearMonthDuration) {
                return left.DateVal + right.DurationVal;
            }

            // date
            // days and time duration
            // date(valuedt-1 (valuedt(e1) +/- valuedtd(e2))) where valuedt and valuedt-1 is 
            // defined in 10.3.2.3.5 and valuedtd is defined in 10.3.2.3.7
            // date
            if (left.ValueType == DataTypeEnum.Date && right.ValueType == DataTypeEnum.DayTimeDuration) {
                return left.DateVal + right.DurationVal;
            }

            throw new FEELException ($"Failed adding l:{left} to r:{right}");

        }

        public static Variable Subtract (Variable left, Variable right) {

            // date and time
            // date and time
            // Addition is undefined. Subtraction is defined as valuedtd-1(valuedt(e1)-valuedt(e2)),
            // where valuedt is defined in 10.3.2.3.5 and valuedtd-1 is defined in 10.3.2.3.7. 
            // In case either value is of type date, it is implicitly converted into a date and time 
            // with time of day of UTC midnight ("00:00:00") as defined in 10.3.2.3.6. 
            // Subtraction requires either both values to have a timezone or both not to have a timezone. 
            // Subtraction is undefined for the case where only one of the values has a timezone.
            // days and time duration
            if (left.ValueType == DataTypeEnum.DateTime && right.ValueType == DataTypeEnum.DateTime) {
                var l = DateAndTimeHelper.DateTimeToInstant (left);
                var r = DateAndTimeHelper.DateTimeToInstant (right);

                var d = l.Item1.Minus (r.Item1);

                return new PeriodBuilder () {
                    Days = d.Days,
                        Hours = d.Hours,
                        Minutes = d.Minutes,
                        Seconds = d.Seconds
                }.Build ();
            }

            // years and months duration
            // years and months duration
            // valueymd-1(valueymd(e1) +/- valueymd(e2)) where valueymd and valueymd-1 is defined in
            // 10.3.2.3.8.
            // years and months duration
            if (left.ValueType == DataTypeEnum.YearMonthDuration && right.ValueType == DataTypeEnum.YearMonthDuration) {
                return left.DurationVal + right.DurationVal;

            }

            // days and time duration
            // days and time duration
            // valuedtd-1(valuedtd(e1) +/- valuedtd(e2)) where valuedtd and valuedtd-1 is defined in 
            // 10.3.2.3.7
            // days and time duration
            if (left.ValueType == DataTypeEnum.DayTimeDuration && right.ValueType == DataTypeEnum.DayTimeDuration) {

            }

            // date and time
            // years and months duration
            // date and time (date(e1.year +/– e2.years + floor((e1.month +/– e2.months)/12),
            // e1.month +/– e2.months – floor((e1.month +/– e2.months)/12) * 12, e1.day), time(e1)),
            // where the named properties are as defined in Table 60 below, and the date, date and time, 
            // time and floor functions are as defined in 10.3.4, 
            // valuedt and valuedt-1 is defined in 10.3.2.3.5 and valueymd is defined in 10.3.2.3.8.
            // date and time
            if (left.ValueType == DataTypeEnum.DateTime && right.ValueType == DataTypeEnum.YearMonthDuration) {

                if (left.DateTimeVal.HasValue) {
                    left.DateTimeVal.Value.Deconstruct (out var ldt, out var of );
                    return new OffsetDateTime (ldt - right.DurationVal, of );
                }

                if (left.LocalDateTimeVal.HasValue) {
                    return left.LocalDateTimeVal.Value - right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return left.ZoneDateTimeVal.Value - right.DurationVal.ToDuration ();
                }

            }

            // date and time
            // days and time duration
            // valuedt-1(valuedt(e1) +/- valuedtd(e2)) where valuedt and valuedt-1 is defined in 10.3.2.3.5 
            // and valuedtd is defined in 10.3.2.3.7.
            // date and time
            if (left.ValueType == DataTypeEnum.DateTime && right.ValueType == DataTypeEnum.DayTimeDuration) {

                if (left.DateTimeVal.HasValue) {
                    left.DateTimeVal.Value.Deconstruct (out var ldt, out var of );
                    return new OffsetDateTime (ldt - right.DurationVal, of );
                }

                if (left.LocalDateTimeVal.HasValue) {
                    return left.LocalDateTimeVal.Value - right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return left.ZoneDateTimeVal.Value - right.DurationVal.ToDuration ();
                }

            }

            // time
            // days and time duration
            // valuet-1(valuet(e1) +/- valuedtd(e2)) where valuet and valuet-1 are defined in 10.3.2.3.4 
            // and valuedtd is defined in 10.3.2.3.7.
            // time
            if (left.ValueType == DataTypeEnum.Time && right.ValueType == DataTypeEnum.DayTimeDuration) {

                if (left.TimeVal.HasValue) {
                    left.TimeVal.Value.Deconstruct (out var lt, out var of );
                    return new OffsetTime (lt - right.DurationVal, of );
                }

                if (left.LocalTimeVal.HasValue) {
                    return left.LocalTimeVal.Value - right.DurationVal;
                }

                if (left.ZoneDateTimeVal.HasValue) {
                    return Variable.Time (left.ZoneDateTimeVal.Value - right.DurationVal.ToDuration ());
                }

            }

            // date
            // years and months duration
            // date( e1.year +/– e2.years + floor((e1.month +/– e2.months)/12), e1.month +/– e2.months – floor((e1.month +/– e2.months)/12) * 12, e1.day ), 
            // where the named properties are as defined in Table 60 below, and the date and floor functions 
            // are as defined in 10.3.4
            // date
            if (left.ValueType == DataTypeEnum.Date && right.ValueType == DataTypeEnum.YearMonthDuration) {
                return left.DateVal - right.DurationVal;
            }

            // date
            // days and time duration
            // date(valuedt-1 (valuedt(e1) +/- valuedtd(e2))) where valuedt and valuedt-1 is 
            // defined in 10.3.2.3.5 and valuedtd is defined in 10.3.2.3.7
            // date
            if (left.ValueType == DataTypeEnum.Date && right.ValueType == DataTypeEnum.DayTimeDuration) {
                return left.DateVal - right.DurationVal;
            }

            throw new FEELException ($"Failed subtracting l:{left} to r:{right}");

        }

    }
}