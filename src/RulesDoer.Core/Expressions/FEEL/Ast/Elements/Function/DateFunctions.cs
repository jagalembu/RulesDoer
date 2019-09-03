using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public static class DateFunctions {

        static private readonly Regex _YM = new Regex (
            @"^(?<sign>-)?P(?<Y>\d+Y)?(?<M>\d+M)?$",
            RegexOptions.Compiled | RegexOptions.Singleline);
        public const string DateFunc = "date";
        public const string DateTimeFunc = "date and time";
        public const string TimeFunc = "time";
        public const string DurationFunc = "duration";
        public const string YearMonthDurationFunc = "years and months duration";

        public static readonly List<string> DateFuncs = new List<string> () {
            DateFunc,
            DateTimeFunc,
            TimeFunc,
            DurationFunc,
            YearMonthDurationFunc
        };

        public static Variable Execute (string functionName, List<Variable> parameters) {
            switch (functionName) {
                case DateFunc:
                    return DateAndTimeHelper.DateFunction (parameters);

                case DateTimeFunc:
                    return DateAndTimeHelper.DateTimeFunction (parameters);

                case TimeFunc:
                    return DateAndTimeHelper.TimeFunction (parameters);

                case DurationFunc:
                    if (parameters.Count == 1) {
                        return DateAndTimeHelper.DurationVal (parameters[0].StringVal);
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                case YearMonthDurationFunc:
                    return DateAndTimeHelper.YearMonthDurationFunction (parameters);

                default:
                    throw new FEELException ($"Date function not supported: {functionName}");
            }
        }

    }
}