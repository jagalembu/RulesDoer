using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class PathExpression : IExpression {
        IExpression Parent;
        string Child;

        public PathExpression (IExpression parent, string child) {
            Parent = parent;
            Child = child;
        }

        public object Execute (VariableContext context = null) {

            var parentVal = Parent.Execute ();

            if (parentVal is Variable parentVar) {

                switch (parentVar.ValueType) {

                    case DataTypeEnum.Context:
                        throw new NotImplementedException ("Need to add the context path expression");
                    case DataTypeEnum.Date:
                    case DataTypeEnum.DateTime:
                    case DataTypeEnum.Time:
                        return DateTimePropertyEvals (parentVar, Child);
                    case DataTypeEnum.DayTimeDuration:
                        return DayTimeDurationPropertyEvals (parentVar, Child);
                    case DataTypeEnum.YearMonthDuration:
                        return YearMonthDurationPropertyEvals (parentVar, Child);
                    default:
                        throw new FEELException ($"Path expression for {parentVar.ValueType} is not supported");
                }
            }

            throw new FEELException ("Parent source is not a variable type");
        }

        private Variable DayTimeDurationPropertyEvals (Variable dayTimeVar, string prop) {
            //days, hours, minutes, seconds
            switch (prop) {
                case "days":
                    return new Variable (dayTimeVar.TimeSpanVal.Days);
                case "hours":
                    return new Variable (dayTimeVar.TimeSpanVal.Hours);
                case "minutes":
                    return new Variable (dayTimeVar.TimeSpanVal.Minutes);
                case "seconds":
                    return new Variable (dayTimeVar.TimeSpanVal.Seconds);
                default:
                    throw new FEELException ($"The following property {prop} is not supported for day time duration type");
            }
        }

        private Variable YearMonthDurationPropertyEvals (Variable yearMonthVar, string prop) {
            switch (prop) {
                case "years":
                    var remainder = yearMonthVar.NumericVal % 12;
                    return new Variable (new Variable ((yearMonthVar.NumericVal - remainder) / 12), new Variable (remainder));
                case "months":
                    return new Variable (new Variable(0), new Variable(yearMonthVar.NumericVal));
                default:
                    throw new FEELException ($"The following property {prop} is not supported for day time duration type");
            }
        }

        private Variable DateTimePropertyEvals (Variable dateVar, string prop) {
            if (dateVar.ValueType == DataTypeEnum.Date || dateVar.ValueType == DataTypeEnum.DateTime) {
                switch (prop) {
                    case "year":
                        return new Variable (dateVar.DateTimeVal.Year);
                    case "month":
                        return new Variable (dateVar.DateTimeVal.Month);
                    case "day":
                        return new Variable (dateVar.DateTimeVal.Day);
                    case "weekday":
                        var dayOfWeek = ((int) dateVar.DateTimeVal.DayOfWeek == 0) ? 7 : (int) dateVar.DateTimeVal.DayOfWeek;
                        return new Variable (dayOfWeek);

                }
            }
            if (dateVar.ValueType == DataTypeEnum.DateTime || dateVar.ValueType == DataTypeEnum.Time) {
                switch (prop) {
                    case "hour":
                        return new Variable (dateVar.DateTimeVal.Hour);
                    case "minute":
                        return new Variable (dateVar.DateTimeVal.Minute);
                    case "second":
                        return new Variable (dateVar.DateTimeVal.Second);
                    case "time offset":
                        throw new NotImplementedException ("Need to add the context path expression");
                    case "timezone":
                        throw new NotImplementedException ("Need to add the context path expression");
                }
            }

            throw new FEELException ($"The following property {prop} is not supported for date type");
        }

    }
}