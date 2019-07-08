using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class DateTimeLiteral : IExpression {

        static private readonly Regex _YM = new Regex (
            @"^(?<sign>-)?P(?<Y>\d+Y)?(?<M>\d+M)?$",
            RegexOptions.Compiled | RegexOptions.Singleline);
        // private static  Pattern DAYS_AND_TIME_DURATION_PATTERN = Pattern.compile("\"[-]?P([0-9]+D)?T?([0-9]+H)?([0-9]+M)?([0-9]+H)?([0-9]+(\\.[0-9]*)?S)?\"");
        // private static  Pattern YEARS_AND_MONTHS_DURATION_PATTERN = Pattern.compile("\"[-]?P([0-9]+Y)?([0-9]+M)?\"");

        public IExpression DateExpression { get; set; }

        public string DateFunction { get; set; }

        public DateTimeLiteral (string dateFunction, IExpression dateExpression) {
            DateFunction = dateFunction;
            DateExpression = dateExpression;
        }

        public object Execute (VariableContext context = null) {
            var dateExprVar = DateExpression.Execute ();

            if (dateExprVar is Variable dateExprOut) {
                switch (DateFunction) {
                    case "date":
                        return Variable.Date (DateTime.Parse (dateExprOut.StringVal));

                    case "date and time":
                        return new Variable (DateTime.Parse (dateExprOut.StringVal));

                    case "time":
                        return Variable.Time (DateTime.Parse (dateExprOut.StringVal));

                    case "duration":
                        var ym = _YM.Match (dateExprOut.StringVal);
                        if (ym.Success) {
                            var signGroup = ym.Groups["sign"];
                            int signedValue = signGroup.Value == "-" ? -1 : 1;

                            var months = 0;

                            var yearsGroup = ym.Groups["Y"];
                            if (yearsGroup.Success)
                                months += int.Parse (yearsGroup.Value.TrimEnd ('Y')) * 12;

                            var monthsGroup = ym.Groups["M"];
                            if (monthsGroup.Success)
                                months += int.Parse (monthsGroup.Value.TrimEnd ('M'));

                            return Variable.Months (months * signedValue);

                        }

                        return new Variable (XmlConvert.ToTimeSpan (dateExprOut.StringVal));

                    default:
                        throw new FEELException ($"The following date function {DateFunction} is not supported");
                }
            }

            throw new FEELException ($"Failed executing date function {DateFunction}");

        }
    }
}