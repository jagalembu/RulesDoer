using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class NumericFunctions {
        public const string Decimal_Func = "decimal";
        public const string Floor_Func = "floor";
        public const string Ceiling_Func = "ceiling";
        public const string Abs_Func = "abs";
        public const string Modulo_Func = "modulo";
        public const string Sqrt_Func = "sqrt";
        public const string Log_Func = "log";
        public const string Exp_Func = "exp";
        public const string Odd_Func = "odd";
        public const string Even_Func = "even";

        public static readonly List<string> NumericFuncs = new List<string> () {
            Decimal_Func,
            Floor_Func,
            Ceiling_Func,
            Abs_Func,
            Modulo_Func,
            Sqrt_Func,
            Log_Func,
            Exp_Func,
            Odd_Func,
            Even_Func
        };

        public static Variable Execute (string functionName, List<Variable> parameters) {
            switch (functionName) {
                case Decimal_Func:
                case Modulo_Func:
                    if (parameters.Count == 2) {
                        if (functionName == Decimal_Func) {
                            return Math.Round (parameters[0].NumericVal, (int) parameters[1].NumericVal);
                        }

                        if (functionName == Modulo_Func) {
                            return (parameters[0].NumericVal % parameters[1].NumericVal);
                        }

                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                case Ceiling_Func:
                case Floor_Func:
                case Abs_Func:
                case Sqrt_Func:
                case Log_Func:
                case Exp_Func:
                case Odd_Func:
                case Even_Func:
                    if (parameters.Count == 1) {
                        switch (functionName) {
                            case Ceiling_Func:
                                return Math.Ceiling (parameters[0].NumericVal);
                            case Abs_Func:
                                return Math.Abs (parameters[0].NumericVal);
                            case Floor_Func:
                                return Math.Floor (parameters[0].NumericVal);
                            case Sqrt_Func:
                                return new Decimal (Math.Sqrt (Double.Parse (parameters[0].NumericVal.ToString ())));
                            case Log_Func:
                                return new Decimal (Math.Log (Double.Parse (parameters[0].NumericVal.ToString ())));
                            case Exp_Func:
                                return new Decimal (Math.Exp (Double.Parse (parameters[0].NumericVal.ToString ())));
                            case Odd_Func:
                                return (parameters[0].NumericVal % 2 != 0);
                            case Even_Func:
                                return (parameters[0].NumericVal % 2 == 0);

                        }
                    }
                    throw new FEELException ($"Incorrect parameters for {functionName} function");

                default:
                    return new Variable ();
            }
        }

    }
}