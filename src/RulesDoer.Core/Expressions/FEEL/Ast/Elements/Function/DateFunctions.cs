using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public static class DateFunctions {

        static private readonly Regex _YM = new Regex (
            @"^(?<sign>-)?P(?<Y>\d+Y)?(?<M>\d+M)?$",
            RegexOptions.Compiled | RegexOptions.Singleline);
        public const string DateFunc = "date";
        public const string DateTimeFunc = "date and time";
        public const string TimeFunc = "time";
        public const string DurationFunc = "duration";

        public static readonly List<string> DateFuncs = new List<string> () {
            DateFunc,
            DateTimeFunc,
            TimeFunc,
            DurationFunc
        };

        public static Variable Execute (string functionName, List<Variable> parameters) {
            switch (functionName) {
                case "date":
                    if (parameters.Count == 1) {
                        switch (parameters[0].ValueType) {
                            case DataTypeEnum.String:
                                return Variable.Date (DateTime.Parse (parameters[0].StringVal));
                            case DataTypeEnum.DateTime:
                                return Variable.Date (parameters[0].DateTimeVal);
                            default:
                                throw new FEELException ($"The date conversion function does not support: {parameters[0].GetType()}");
                        }
                    }
                    if (parameters.Count == 3) {
                        return Variable.Date (new DateTime ((int) parameters[0].NumericVal, (int) parameters[1].NumericVal, (int) parameters[2].NumericVal));
                    }

                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                case "date and time":
                    if (parameters.Count == 1) {
                        return new Variable (DateTime.Parse (parameters[0].StringVal));
                    }
                    if (parameters.Count == 2) { 
                        //TODO: Add time offsets       
                        return parameters[0].DateTimeVal.Add(parameters[1].DateTimeVal.TimeOfDay);                        
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                case "time":
                    //return Variable.Time (DateTime.Parse (dateExprOut.StringVal));
                    throw new FEELException ($"Incorrect parameters for {functionName} function");


                case "duration":
                    if (parameters.Count == 1) {
                        var ym = _YM.Match (parameters[0].StringVal);
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
                        return new Variable (XmlConvert.ToTimeSpan (parameters[0].StringVal));

                    }

                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                default:
                    throw new FEELException ($"Date function not supported: {functionName}");
            }
        }

    }
}