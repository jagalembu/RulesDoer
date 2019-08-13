using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.XPath;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class StringFunctions {
        public const string Substring = "substring";
        public const string String_Length = "string length";
        public const string Upper_Case = "upper case";
        public const string Lower_Case = "lower case";
        public const string Substring_Before = "substring before";
        public const string Substring_After = "substring after";
        public const string Replace = "replace";
        public const string Contains = "contains";
        public const string Starts_With = "starts with";
        public const string End_With = "ends with";
        public const string Matches = "matches";
        public const string Split = "split";
        public const string StringFunc = "string";

        public static readonly List<string> StringFuncs = new List<string> {
            Substring,
            String_Length,
            Upper_Case,
            Lower_Case,
            Substring_Before,
            Substring_After,
            Replace,
            Contains,
            Starts_With,
            End_With,
            Matches,
            Split,
            StringFunc
        };

        public static Variable Execute (string functionName, List<Variable> parameters) {

            switch (functionName) {
                case StringFunc:
                    if (parameters.Count == 1) {
                        return parameters[0].ToString ();
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Substring:
                    if (parameters.Count == 2) {
                        var startIndex = int.Parse (parameters[1].NumericVal.ToString ());
                        return parameters[0].StringVal.Substring (startIndex > 0 ? startIndex - 1 : parameters[0].StringVal.Length - (startIndex * -1));
                    }
                    if (parameters.Count == 3) {
                        var startIndex = int.Parse (parameters[1].NumericVal.ToString ());
                        return parameters[0].StringVal.Substring (startIndex > 0 ? startIndex - 1 : parameters[0].StringVal.Length - (startIndex * -1), int.Parse (parameters[2].NumericVal.ToString ()));
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case String_Length:
                    if (parameters.Count == 1) {
                        return new Variable (parameters[0].StringVal.Length);
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Upper_Case:
                case Lower_Case:
                    if (parameters.Count == 1) {
                        var caseStr = (functionName == Upper_Case) ? parameters[0].StringVal.ToUpper () : parameters[0].StringVal.ToLower ();
                        return caseStr;
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Substring_Before:
                case Substring_After:
                    if (parameters.Count == 2) {

                        if (functionName == Substring_Before) {
                            var indexStart = parameters[0].StringVal.IndexOf (parameters[1].StringVal);
                            if (indexStart < 0) {
                                return "";
                            }
                            return parameters[0].StringVal.Substring (0, indexStart);
                        }

                        if (functionName == Substring_After) {
                            var indexStart = parameters[0].StringVal.IndexOf (parameters[1].StringVal);
                            if (indexStart < 0) {
                                return "";
                            }
                            return parameters[0].StringVal.Substring (indexStart + parameters[1].StringVal.Length);
                        }

                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Replace:
                    RegexOptions flagOpts = RegexOptions.None;
                    if (parameters.Count == 4) {
                        flagOpts = MatchesOptions (parameters[3]);
                    }
                    if (parameters.Count <= 3) {
                        return Regex.Replace (parameters[0], parameters[1], parameters[2], flagOpts);
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Contains:
                case Starts_With:
                case End_With:
                case Split:
                    if (parameters.Count == 2) {
                        if (functionName == Contains) {
                            return parameters[0].StringVal.Contains (parameters[1]);
                        }
                        if (functionName == Starts_With) {
                            return parameters[0].StringVal.StartsWith (parameters[1]);
                        }
                        if (functionName == End_With) {
                            return parameters[0].StringVal.EndsWith (parameters[1]);
                        }
                        if (functionName == Split) {
                            var strs = parameters[0].StringVal.Split (parameters[1].StringVal, StringSplitOptions.None);
                            List<Variable> listStr = new List<Variable> ();
                            foreach (var item in strs) {
                                listStr.Add (new Variable (item));
                            }

                            return new Variable (listStr);
                        }
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");
                case Matches:
                    RegexOptions flags_m = RegexOptions.None;
                    if (parameters.Count == 3) {
                        flags_m = MatchesOptions (parameters[2]);
                    }
                    if (parameters.Count <= 3) {
                        var matchesFnd = Regex.Match (parameters[0], parameters[1], flags_m);
                        return matchesFnd.Success;
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                default:
                    return new Variable ();
            }

        }

        private static RegexOptions MatchesOptions (Variable flagExpr) {

            if (flagExpr.ValueType == DataTypeEnum.String) {
                RegexOptions opts = RegexOptions.None;
                foreach (char item in flagExpr.StringVal) {
                    switch (item) {
                        case 's':
                            opts |= RegexOptions.Singleline;
                            break;
                        case 'm':
                            opts |= RegexOptions.Multiline;
                            break;
                        case 'i':
                            opts |= RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
                            break;
                        case 'x':
                            opts |= RegexOptions.IgnorePatternWhitespace;
                            break;

                        default:
                            throw new FEELException ($"Regex option {item} is not supported");
                    }
                }

                return opts;

            }

            throw new FEELException ("Regex option flag is incorrect type");
        }

    }
}