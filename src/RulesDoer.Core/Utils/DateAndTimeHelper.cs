using System;
using System.Collections.Generic;
using NodaTime;
using NodaTime.Text;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Utils {
    public static partial class DateAndTimeHelper {
        public static ZonedDateTimePattern _zoneDtPattern = ZonedDateTimePattern.CreateWithInvariantCulture ("uuuu'-'MM'-'dd'T'HH':'mm':'ss;FFFFFFFFF@z", DateTimeZoneProviders.Tzdb);
        public static ZonedDateTimePattern _zoneTmPattern = ZonedDateTimePattern.CreateWithInvariantCulture ("HH':'mm':'ss;FFFFFFFFF@z", DateTimeZoneProviders.Tzdb);

        public static OffsetTimePattern _offsetTimePatternWithSecondsOffset = OffsetTimePattern.CreateWithInvariantCulture ("HH':'mm':'ss;FFFFFFFFFo<Z+HH:mm:ss>");

        public static Variable DateTimeVal (string input) {

            if (input.Contains ('@')) {
                var zoneDt = _zoneDtPattern.Parse (input).Value;
                return zoneDt;
            }

            var ofstDt = OffsetDateTimePattern.Rfc3339.Parse (input);

            if (ofstDt.Success) {
                return ofstDt.Value;
            }

            var localDt = LocalDateTimePattern.ExtendedIso.Parse (input);
            if (localDt.Success) {
                return localDt.Value;
            }

            var ldt = LocalDatePattern.Iso.Parse (input);
            if (ldt.Success) {
                return new LocalDateTime (ldt.Value.Year, ldt.Value.Month, ldt.Value.Day, 0, 0);
            }

            throw new FEELException ($"Failed parsing date time string: {input}");

        }

        public static Variable DateVal (string input) {
            var localDt = LocalDatePattern.Iso.Parse (input).Value;
            return localDt;
        }

        public static Variable TimeVal (string input) {

            if (input.Contains ('@')) {
                var zoneDt = _zoneTmPattern.WithTemplateValue (Instant.FromUtc (1970, 1, 1, 11, 30).InZone (DateTimeZone.Utc)).Parse (input).Value;
                return Variable.Time (zoneDt);
            }

            var ofstTm = OffsetTimePattern.Rfc3339.Parse (input);

            if (ofstTm.Success) {
                return ofstTm.Value;
            }

            var localTm = LocalTimePattern.ExtendedIso.Parse (input);
            if (localTm.Success) {
                return localTm.Value;
            }

            return new Variable ();

        }

        public static Variable DurationVal (string input) {

            var durationVal = input;
            bool neg = false;
            if (input.StartsWith ('-')) {
                durationVal = input.TrimStart ('-');
                neg = true;
            }
            var dur = PeriodPattern.NormalizingIso.Parse (durationVal);

            if (dur.Success) {
                var val = dur.Value;
                if (neg) {
                    var negVal = new PeriodBuilder {
                        Years = (val.Years > 0) ? val.Years * -1 : 0,
                            Months = (val.Months > 0) ? val.Months * -1 : 0,
                            Weeks = (val.Weeks > 0) ? val.Weeks * -1 : 0,
                            Days = (val.Days > 0) ? val.Days * -1 : 0,
                            Hours = (val.Hours > 0) ? val.Hours * -1 : 0,
                            Minutes = (val.Minutes > 0) ? val.Minutes * -1 : 0,
                            Seconds = (val.Seconds > 0) ? val.Seconds * -1 : 0,
                            Milliseconds = (val.Milliseconds > 0) ? val.Milliseconds * -1 : 0,
                            Ticks = (val.Ticks > 0) ? val.Ticks * -1 : 0
                    }.Build ();
                    return negVal;
                }
                return dur.Value;
            }

            return new Variable ();
        }

        public static string DateTimeString (Variable input) {

            if (input.ZoneDateTimeVal.HasValue) {
                return _zoneDtPattern.Format (input.ZoneDateTimeVal.Value);
            }

            if (input.DateTimeVal.HasValue) {
                return OffsetDateTimePattern.Rfc3339.Format (input.DateTimeVal.Value);
            }

            if (input.LocalDateTimeVal.HasValue) {
                return LocalDateTimePattern.ExtendedIso.Format (input.LocalDateTimeVal.Value);
            }

            return null;
        }

        public static string DateString (LocalDate input) {
            return LocalDatePattern.Iso.Format (input);
        }

        public static string TimeString (Variable input) {
            if (input.ZoneDateTimeVal.HasValue) {
                return _zoneTmPattern.Format (input.ZoneDateTimeVal.Value);
            }

            if (input.TimeVal.HasValue) {
                //return OffsetTimePattern.Rfc3339.Format (input.TimeVal.Value);
                return _offsetTimePatternWithSecondsOffset.Format (input.TimeVal.Value);

            }

            if (input.LocalTimeVal.HasValue) {
                return LocalTimePattern.ExtendedIso.Format (input.LocalTimeVal.Value);
            }
            return null;
        }

        public static string DurationString (Period input) {
            return PeriodPattern.NormalizingIso.Format (input);
        }

        public static int CompareDateTime (Variable vA, Variable vB) {
            var l = DateTimeToInstant (vA);
            var r = DateTimeToInstant (vB);
            return l.Item1.CompareTo (r.Item1);
        }

        public static int CompareDate (Variable vA, Variable vB) {
            return vA.DateVal.CompareTo (vB);
        }

        public static int CompareTime (Variable vA, Variable vB) {
            if (vA.LocalTimeVal.HasValue) {
                return vA.LocalTimeVal.Value.CompareTo (vB.LocalTimeVal.Value);
            }

            if (vA.TimeVal.HasValue) {
                var dfDt = new LocalDate (1970, 1, 1);
                return vA.TimeVal.Value.On (dfDt).ToInstant ().CompareTo (vB.TimeVal.Value.On (dfDt).ToInstant ());
            }

            if (vA.ZoneDateTimeVal.HasValue) {
                return vA.ZoneDateTimeVal.Value.ToInstant ().CompareTo (vB.ZoneDateTimeVal.Value.ToInstant ());
            }

            throw new FEELException ("Unable to compare time values");
        }

        public static int CompareDuration (Variable vA, Variable vB) {
            var comparer = Period.CreateComparer (new LocalDateTime (0, 1, 1, 0, 0));
            return comparer.Compare (vA.DurationVal, vB.DurationVal);
        }

        public static (Instant, DateTimeZone) DateTimeToInstant (Variable dt) {
            if (dt.ZoneDateTimeVal.HasValue) {
                return (dt.ZoneDateTimeVal.Value.ToInstant (), dt.ZoneDateTimeVal.Value.Zone);
            }
            if (dt.DateTimeVal.HasValue) {
                return (dt.DateTimeVal.Value.ToInstant (), null);
            }
            if (dt.LocalDateTimeVal.HasValue) {
                return (new OffsetDateTime (dt.LocalDateTimeVal.Value, Offset.Zero).ToInstant (), null);
            }

            throw new FEELException ("Unable to determine Instant value of the datetime");
        }

        public static Variable DatePropEvals (Variable dt, string prop) {
            switch (prop) {
                case "year":
                    return new Variable (dt.DateVal.Year);
                case "month":
                    return new Variable (dt.DateVal.Month);
                case "day":
                    return new Variable (dt.DateVal.Day);
                default:
                    throw new FEELException ($"The following property {prop} is not supported for date type");

            }
        }

        public static Variable DurationPropEvals (Variable dt, string prop) {
            switch (prop) {
                case "days":
                    return dt.DurationVal.Days;
                case "hours":
                    return dt.DurationVal.Hours;
                case "minutes":
                    return dt.DurationVal.Minutes;
                case "seconds":
                    return dt.DurationVal.Seconds;
                case "months":
                    return dt.DurationVal.Months + (dt.DurationVal.Years * 12);
                case "years":
                    return dt.DurationVal.Years;
                default:
                    throw new FEELException ($"The following property {prop} is not supported for day time duration type");
            }
        }

        public static Variable DateTimePropEvals (Variable dt, string prop) {
            if (dt.ZoneDateTimeVal.HasValue) {
                switch (prop) {
                    case "year":
                        return new Variable (dt.ZoneDateTimeVal.Value.Year);
                    case "month":
                        return new Variable (dt.ZoneDateTimeVal.Value.Month);
                    case "day":
                        return new Variable (dt.ZoneDateTimeVal.Value.Day);
                    case "weekday":
                        return new Variable ((int) dt.ZoneDateTimeVal.Value.DayOfWeek);
                    case "hour":
                        return new Variable (dt.ZoneDateTimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.ZoneDateTimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.ZoneDateTimeVal.Value.Second);
                    case "timezone":
                        return dt.ZoneDateTimeVal.Value.Zone.ToString ();
                }
            }

            if (dt.DateTimeVal.HasValue) {
                switch (prop) {
                    case "year":
                        return new Variable (dt.DateTimeVal.Value.Year);
                    case "month":
                        return new Variable (dt.DateTimeVal.Value.Month);
                    case "day":
                        return new Variable (dt.DateTimeVal.Value.Day);
                    case "weekday":
                        return new Variable ((int) dt.DateTimeVal.Value.DayOfWeek);
                    case "hour":
                        return new Variable (dt.DateTimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.DateTimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.DateTimeVal.Value.Second);
                    case "time offset":
                        var per = new PeriodBuilder { Seconds = dt.DateTimeVal.Value.Offset.Seconds }.Build ();
                        return new Variable (per);
                }
            }

            if (dt.LocalDateTimeVal.HasValue) {
                switch (prop) {
                    case "year":
                        return new Variable (dt.LocalDateTimeVal.Value.Year);
                    case "month":
                        return new Variable (dt.LocalDateTimeVal.Value.Month);
                    case "day":
                        return new Variable (dt.LocalDateTimeVal.Value.Day);
                    case "weekday":
                        return new Variable ((int) dt.LocalDateTimeVal.Value.DayOfWeek);
                    case "hour":
                        return new Variable (dt.LocalDateTimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.LocalDateTimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.LocalDateTimeVal.Value.Second);
                }
            }

            throw new FEELException ($"Failed to determine the propery value for date time: {prop}");

        }

        public static Variable TimePropEvals (Variable dt, string prop) {
            if (dt.ZoneDateTimeVal.HasValue) {
                switch (prop) {
                    case "hour":
                        return new Variable (dt.ZoneDateTimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.ZoneDateTimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.ZoneDateTimeVal.Value.Second);
                    case "timezone":
                        return dt.ZoneDateTimeVal.Value.Zone.ToString ();
                }
            }

            if (dt.TimeVal.HasValue) {
                switch (prop) {
                    case "hour":
                        return new Variable (dt.TimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.TimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.TimeVal.Value.Second);
                    case "time offset":
                        var per = new PeriodBuilder { Seconds = dt.TimeVal.Value.Offset.Seconds }.Build ();
                        return new Variable (per);
                }
            }

            if (dt.LocalTimeVal.HasValue) {
                switch (prop) {

                    case "hour":
                        return new Variable (dt.LocalTimeVal.Value.Hour);
                    case "minute":
                        return new Variable (dt.LocalTimeVal.Value.Minute);
                    case "second":
                        return new Variable (dt.LocalTimeVal.Value.Second);
                }
            }

            throw new FEELException ($"Failed to determine the propery value for date time: {prop}");

        }

        public static Variable DateFunction (List<Variable> parameters) {
            if (parameters.Count == 1) {
                switch (parameters[0].ValueType) {
                    case DataTypeEnum.String:
                        return DateVal (parameters[0].StringVal);
                    case DataTypeEnum.DateTime:
                        if (parameters[0].ZoneDateTimeVal.HasValue) {
                            return parameters[0].ZoneDateTimeVal.Value.Date;
                        } else if (parameters[0].DateTimeVal.HasValue) {
                            return parameters[0].DateTimeVal.Value.Date;
                        } else if (parameters[0].LocalDateTimeVal.HasValue) {
                            return parameters[0].LocalDateTimeVal.Value.Date;
                        }
                        throw new FEELException ("Date time value is not populated to get a date");
                    case DataTypeEnum.Date:
                        return parameters[0].DateVal;
                    default:
                        throw new FEELException ($"The date conversion function does not support: {parameters[0].GetType()}");
                }
            }

            if (parameters.Count == 3) {
                foreach (var item in parameters) {
                    if (item.ValueType != DataTypeEnum.Decimal) {
                        throw new FEELException ($"Parameter variables all have to be numeric values for date function");
                    }
                }
                return new LocalDate ((int) parameters[0].NumericVal, (int) parameters[1].NumericVal, (int) parameters[2].NumericVal);
            }

            throw new FEELException ("Failed retrieving a date value due to incorrect number of parameters");
        }

        public static Variable DateTimeFunction (List<Variable> parameters) {
            if (parameters.Count == 1) {
                return DateTimeVal (parameters[0].StringVal);
            }
            if (parameters.Count == 2) {
                return DateAppendTime (parameters[0], parameters[1]);
            }

            throw new FEELException ("Failed retrieving a date time value due to incorrect number of parameters");
        }

        public static Variable YearMonthDurationFunction (List<Variable> parameters) {
            if (parameters.Count == 2) {
                foreach (var item in parameters) {
                    if (item.ValueType != DataTypeEnum.Date && item.ValueType != DataTypeEnum.DateTime) {
                        throw new FEELException ($"Incorrect data types for year month duration function: {item}");
                    }
                }

                LocalDate leftDt = LocalDate.MinIsoValue;
                LocalDate rightDt = LocalDate.MinIsoValue;;
                if (parameters[0].ValueType == DataTypeEnum.DateTime) {
                    leftDt = DateTimeToDate (parameters[0]);
                }
                if (parameters[0].ValueType == DataTypeEnum.Date) {
                    leftDt = parameters[0].DateVal;
                }
                if (parameters[1].ValueType == DataTypeEnum.DateTime) {
                    rightDt = DateTimeToDate (parameters[1]);
                }
                if (parameters[1].ValueType == DataTypeEnum.Date) {
                    rightDt = parameters[1].DateVal;
                }

                var per = (rightDt - leftDt);

                return new PeriodBuilder { Years = per.Years, Months = per.Months }.Build ();
            }

            throw new FEELException ("Failed retrieving a year month duration value to incorrect number of parameters");
        }

        public static Variable TimeFunction (List<Variable> parameters) {
            if (parameters.Count == 1) {
                switch (parameters[0].ValueType) {
                    //time(from) time string
                    case DataTypeEnum.String:
                        return TimeVal (parameters[0].StringVal);

                        //time(from) date and time
                    case DataTypeEnum.DateTime:
                        return DateTimeToTime (parameters[0]);

                        //time(from) time
                    case DataTypeEnum.Time:
                        return parameters[0];

                        //supposedly date without time is an option
                        //return UTC time
                    case DataTypeEnum.Date:
                        return TimeVal ("00:00:00Z");

                }

            }

            //time(hour, minute,second, offset) hour, minute, second, are numbers, offset is a days and time duration, or null

            if (parameters.Count == 3) {
                foreach (var item in parameters) {
                    if (item.ValueType != DataTypeEnum.Decimal) {
                        throw new FEELException ($"Parameter variables all have to be numeric values for time function");
                    }
                }
                var ldt = CreateLocalTime (parameters[0].NumericVal, parameters[1].NumericVal, parameters[2].NumericVal);
                return ldt;
            }
            if (parameters.Count == 4) {
                for (int i = 0; i < parameters.Count - 1; i++) {
                    if (parameters[i].ValueType != DataTypeEnum.Decimal) {
                        throw new FEELException ($"Parameter variables all have to be numeric values for time function");
                    }
                }
                var ldt = CreateLocalTime (parameters[0].NumericVal, parameters[1].NumericVal, parameters[2].NumericVal);

                if (parameters[3].ValueType == DataTypeEnum.Duration) {
                    var pr = parameters[3].DurationVal;
                    var ofs = Offset.FromHoursAndMinutes ((int) pr.Hours, (int) pr.Minutes);
                    ofs = ofs.Plus (Offset.FromSeconds ((int) pr.Seconds));

                    return new OffsetTime (ldt, ofs);
                }

                return ldt;

            }

            throw new FEELException ("Failed retrieving a date time value due to incorrect number of parameters");

        }

        public static LocalDate DateTimeToDate (Variable input) {

            if (input.ValueType != DataTypeEnum.DateTime) {
                throw new FEELException ("Expected a datetime value type");
            }

            if (input.ZoneDateTimeVal.HasValue) {
                return input.ZoneDateTimeVal.Value.Date;
            }

            if (input.DateTimeVal.HasValue) {
                return input.DateTimeVal.Value.Date;
            }

            if (input.LocalDateTimeVal.HasValue) {
                return input.LocalDateTimeVal.Value.Date;
            }

            throw new FEELException ($"Failed retrieving date from {input}");
        }

        public static Variable DateTimeToTime (Variable input) {

            if (input.ValueType != DataTypeEnum.DateTime) {
                throw new FEELException ("Expected a datetime value type");
            }

            if (input.ZoneDateTimeVal.HasValue) {
                return Variable.Time (input.ZoneDateTimeVal.Value);
            }

            if (input.DateTimeVal != null) {
                input.DateTimeVal.Value.Deconstruct (out var dt, out var of );
                dt.Deconstruct (out var ldt, out var ltm);
                return new OffsetTime (ltm, of );
            }

            if (input.LocalDateTimeVal != null) {
                input.LocalDateTimeVal.Value.Deconstruct (out var ldt, out var ltm);
                return ltm;
            }

            throw new FEELException ($"Failed retrieving time from {input}");
        }

        public static Variable DateAppendTime (Variable inDt, Variable inTm) {

            if (inDt.ValueType != DataTypeEnum.DateTime && inDt.ValueType != DataTypeEnum.Date) {
                throw new FEELException ($"Expected a datetime or date value type {inDt}");
            }

            if (inTm.ValueType != DataTypeEnum.Time) {
                throw new FEELException ($"Expected a time value type {inTm}");
            }

            LocalDate dt = LocalDate.MaxIsoValue;

            if (inDt.ValueType == DataTypeEnum.DateTime) {
                dt = DateTimeToDate (inDt);
            }
            if (inDt.ValueType == DataTypeEnum.Date) {
                dt = inDt.DateVal;
            }

            if (inTm.LocalTimeVal.HasValue) {
                return (dt + inTm.LocalTimeVal.Value);
            }
            if (inTm.ZoneDateTimeVal.HasValue) {
                inTm.ZoneDateTimeVal.Value.Deconstruct (out var zdt, out var zn, out var zof);
                zdt.Deconstruct (out var ldt, out var lt);
                return (dt + lt).InZoneStrictly (zn);
            }
            if (inTm.TimeVal.HasValue) {
                inTm.TimeVal.Value.Deconstruct (out var olt, out var oof);
                return new OffsetDateTime ((dt + olt), oof);
            }

            throw new FEELException ($"Failed appending date {inDt} to time {inTm}");

        }

        public static LocalTime CreateLocalTime (decimal hours, decimal mins, decimal secs) {

            long nsecs = 0;
            var xsecsfractions = secs - Math.Truncate (secs);
            if (xsecsfractions > 0) {
                nsecs = (long) (xsecsfractions * 1000000000);
            }

            if (nsecs > 0) {
                return LocalTime.FromHourMinuteSecondNanosecond ((int) hours, (int) mins, (int) secs, nsecs);
            }

            return new LocalTime ((int) hours, (int) mins, (int) secs);

        }

    }
}