using System.Text.RegularExpressions;
using System.Xml;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Utils {
    public static class DurationHelper {
        static private readonly Regex _YM = new Regex (
            @"^(?<sign>-)?P(?<Y>\d+Y)?(?<M>\d+M)?$",
            RegexOptions.Compiled | RegexOptions.Singleline);
        public static Variable MakeYearMonth (string value) {
            var ym = _YM.Match (value);
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
            throw new DMNException ($"Incorrect year month duration format: {value}");

        }

        public static Variable MakeDayTime (string value) {
            return new Variable (XmlConvert.ToTimeSpan (value));
        }

    }
}