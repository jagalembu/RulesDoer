using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Utils;
using Xunit;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class EvaluationExpressionTests {

        [Theory]
        [InlineData ("not(true)", false)]
        [InlineData ("not(A)", false)]
        public void Evaluate_Not (string exprText, bool expected) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "A", true }, { "B", false }, { "stringval", "blah" } };

            var variable = ParseAndEval (exprText, context);
            Assert.Equal<bool> (expected, variable);
        }

        [Theory]
        [InlineData ("years and months duration(from:date(\"2011-12-22\"),to:date(\"2013-08-24\"))", "P1Y8M")]
        public void Evaluate_YearAndMonthDurationFunc (string exprText, string expected) {
            Variable variable = ParseAndEval (exprText);

            var expectedVal = DateAndTimeHelper.DurationVal (expected);

            Assert.Equal<Variable> (expectedVal, variable);

        }

        [Theory]
        [ClassData (typeof (BoxedListDataTests))]
        public void EvaluateExpression_Boxed_List (string exprText, Variable expected, Boolean expectedEqual) {
            Variable variable = ParseAndEval (exprText);
            if (expectedEqual) {
                Assert.True (variable.Equals (expected));
            } else {
                Assert.False (variable.Equals (expected));
            }

        }

        [Theory]
        [ClassData (typeof (ListFilterTests))]
        public void EvaluateExpression_List_Filter (string exprText, Variable expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.True (variable.Equals (expected));

        }

        [Theory]
        [ClassData (typeof (ContextDataTests))]
        public void EvaluateExpression_Boxed_Context (string exprText, Variable expected, Boolean expectedEqual) {
            Variable variable = ParseAndEval (exprText);
            if (expectedEqual) {
                Assert.True (variable.Equals (expected));
            } else {
                Assert.False (variable.Equals (expected));
            }

        }

        [Theory]
        [InlineData ("string length(stringval)", null, 4, null)]
        [InlineData ("substring(\"foobar\",3)", "obar", null, null)]
        [InlineData ("substring(\"foobar\",3,3)", "oba", null, null)]
        [InlineData ("substring(\"foobar\",-2, 1)", "a", null, null)]
        [InlineData ("string length(\"foo\")", null, 3, null)]
        [InlineData ("upper case(\"aBc4\")", "ABC4", null, null)]
        [InlineData ("lower case(\"aBc4\")", "abc4", null, null)]
        [InlineData ("substring before(\"foobar\", \"bar\")", "foo", null, null)]
        [InlineData ("substring before(\"foobar\", \"xyz\")", "", null, null)]
        [InlineData ("substring after(\"foobar\", \"ob\")", "ar", null, null)]
        [InlineData ("substring after(\"\", \"a\")", "", null, null)]
        [InlineData ("contains(\"foobar\", \"fo\")", null, null, true)]
        [InlineData ("contains(\"foobar\", \"x\")", null, null, false)]
        [InlineData ("starts with(\"foobar\", \"fo\")", "", null, true)]
        [InlineData ("starts with(\"foobar\", \"x\")", "", null, false)]
        [InlineData ("ends with(\"foobar\", \"r\")", "", null, true)]
        [InlineData ("ends with(\"foobar\", \"x\")", "", null, false)]
        [InlineData ("matches(\"foobar\", \"^fo*b\")", "", null, true)]
        [InlineData ("matches(\"foobar\", \"^fo*v\")", "", null, false)]
        [InlineData ("matches(\"Foobar\", \"^fo*b\", \"i\")", "", null, true)]
        [InlineData ("matches(\"helloworld\", \"hello world\", \"x\")", "", null, true)]
        [InlineData ("matches(\"Helloworld\", \"hello world\", \"ix\")", "", null, true)]
        [InlineData ("replace(\"abcd\", \"(ab)|(a)\", \"[1=$1][2=$2]\") ", "[1=ab][2=]cd", null, null)]
        public void EvaluateExpression_FunctionInvocation_StringFuncs (string exprText, string expectedStr, int? expectedInt, Boolean? expectedBool) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "stringval", "blah" } };

            Variable variable = ParseAndEval (exprText, context);
            if (!string.IsNullOrWhiteSpace (expectedStr)) {
                Assert.Equal<string> (expectedStr, variable);
            } else if (expectedBool.HasValue) {
                Assert.Equal<Boolean> (expectedBool.Value, variable);
            } else if (expectedInt.HasValue) {
                Assert.Equal<int> (expectedInt.Value, (int) variable.NumericVal);
            }

        }

        [Theory]
        [InlineData ("decimal(1/3,2)", "0.33", null)]
        [InlineData ("decimal(1.5,0)", "2", null)]
        [InlineData ("decimal(2.5,0)", "2", null)]
        [InlineData ("decimal(n:15/78*2,scale:3)", "0.385", null)]
        [InlineData ("floor(1.5)", "1", null)]
        [InlineData ("floor(-1.5)", "-2", null)]
        [InlineData ("ceiling(1.5)", "2", null)]
        [InlineData ("ceiling(-1.5)", "-1", null)]
        [InlineData ("abs( 10 )", "10", null)]
        [InlineData ("abs( -10 )", "10", null)]
        [InlineData ("modulo( 12, 5 )", "2", null)]
        [InlineData ("sqrt( 16 )", "4", null)]
        [InlineData ("log( 10 )", "2.30258509299405", null)]
        [InlineData ("exp( 5 )", "148.413159102577", null)]
        [InlineData ("odd( 5 )", null, true)]
        [InlineData ("odd( 2 )", null, false)]
        [InlineData ("even( 5 )", null, false)]
        [InlineData ("even ( 2 )", null, true)]
        [InlineData ("number(from: \"1.000.000,01\", decimal separator:\",\", grouping separator:\".\")", "1000000.01", null)]
        public void EvaluateExpression_FunctionInvocation_NumericFuncs (string exprText, string expectedStr, Boolean? expectedBool) {
            Variable variable = ParseAndEval (exprText);
            if (!string.IsNullOrWhiteSpace (expectedStr)) {
                Assert.Equal<Decimal> (Decimal.Parse (expectedStr), variable);
            } else if (expectedBool.HasValue) {
                Assert.Equal<bool> (expectedBool.Value, variable);
            }

        }

        [Theory]
        [InlineData ("all([])", true)]
        [InlineData ("all(true)", true)]
        [InlineData ("any([])", false)]
        [InlineData ("any(true)", true)]
        public void EvaluateExpression_FunctionInvocation_All_Any (string exprText, bool expected) {
            Variable variable = ParseAndEval (exprText);
            Assert.Equal<bool> (expected, variable);

        }

        [Theory]
        [InlineData ("date(\"2015-12-24\").year", 2015)]
        [InlineData ("date(\"2015-12-24\").month", 12)]
        [InlineData ("date(\"2015-12-24\").day", 24)]
        public void EvaluateExpression_PathExpression_Date (string exprText, Decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Decimal> (expected, variable);
        }

        [Theory]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").year", 2016)]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").month", 12)]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").day", 24)]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").hour", 23)]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").minute", 59)]
        [InlineData ("date and time(\"2016-12-24T23:59:00-08:00\").second", 0)]
        public void EvaluateExpression_PathExpression_DateTime (string exprText, Decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Decimal> (expected, variable);
        }

        [Theory]
        [InlineData ("time(\"23:59:01\").hour", 23)]
        [InlineData ("time(\"23:59:01\").minute", 59)]
        [InlineData ("time(\"23:59:01\").second", 1)]
        public void EvaluateExpression_PathExpression_Time (string exprText, Decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Decimal> (expected, variable);
        }

        [Theory]
        [InlineData ("duration(\"P13DT2H14S\").days", 13)]
        [InlineData ("duration(\"P13DT2H14S\").hours", 2)]
        [InlineData ("duration(\"P13DT2H14S\").minutes", 0)]
        [InlineData ("duration(\"P13DT2H14S\").seconds", 14)]
        public void EvaluateExpression_PathExpression_DurationDayAndTime (string exprText, Decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Decimal> (expected, variable);
        }

        [Theory]
        [InlineData ("duration(\"P1Y3M\").years", 1)]
        [InlineData ("duration(\"P1Y3M\").months", 3)]
        public void EvaluateExpression_PathExpression_DurationYearsAndMonths (string exprText, Decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Decimal> (expected, variable.NumericVal);

        }

        [Theory]
        [InlineData ("true instance of boolean", true)]
        [InlineData ("true instance of number", false)]
        public void EvaluateExpression_InstanceOf (string exprText, Boolean expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Boolean> (expected, variable);
        }

        [Theory]
        [ClassData (typeof (DateFunctionDataTests))]
        public void EvaluateExpression_Date_Function (string exprText, Variable expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Variable> (expected, variable);
        }

        [Theory]
        [ClassData (typeof (DurationFunctionDataTests))]
        public void EvaluateExpression_Duration_Function (string exprText, Variable expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Variable> (expected, variable);
        }

        [Theory]
        [ClassData (typeof (DurationYearMonthDataTests))]
        public void EvaluateExpression_Duration_YearMonth_Function (string exprText, Variable expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<Variable> (expected, variable);
        }

        [Theory]
        [InlineData ("true or true", true)]
        [InlineData ("true or false", true)]
        [InlineData ("false or false", false)]
        [InlineData ("true or false or false", true)]
        [InlineData ("true or (false or false)", true)]
        [InlineData ("true and true", true)]
        [InlineData ("true and true and true", true)]
        [InlineData ("true and true and false", false)]
        [InlineData ("true and (true and false)", false)]
        [InlineData ("true and false", false)]
        [InlineData ("false and false", false)]
        public void EvaluateExpression_Disjunction_Conjuction (string exprText, bool expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<bool> (expected, variable);

        }

        [Theory]
        [InlineData ("1 == 1", true)]
        [InlineData ("1 = 1", true)]
        [InlineData ("1 != 1", false)]
        [InlineData ("1 != 2", true)]
        [InlineData ("1 + 1 = 1 + 1", true)]
        [InlineData ("1 > 1", false)]
        [InlineData ("1 >= 1", true)]
        [InlineData ("1 >= 0", true)]
        [InlineData ("1 < 2", true)]
        [InlineData ("1 < 1", false)]
        [InlineData ("-1 < 0", true)]
        [InlineData ("-1 <= -1", true)]
        public void EvaluateExpression_Comparison_NumericVal (string exprText, bool expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<bool> (expected, variable);

        }

        [Theory]
        [InlineData ("true", true)]
        [InlineData ("false", false)]
        public void EvaluateExpression_Bool (string exprText, bool expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<bool> (expected, variable);

        }

        [Theory]
        [InlineData ("1.234", 1.234)]
        [InlineData ("42", 42)]
        public void EvaluateExpression_Numeric (string exprText, decimal expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<decimal> (expected, variable);

        }

        [Theory]
        [InlineData ("\"x1.234\"", "x1.234")]
        [InlineData ("\"42x\"", "42x")]
        [InlineData ("\"what is a ball?\"", "what is a ball?")]
        public void EvaluateExpression_String (string exprText, string expected) {
            Variable variable = ParseAndEval (exprText);

            Assert.Equal<string> (expected, variable);

        }

        [Theory]
        [InlineData ("\"x1.234\" + item1", "x1.234somevalue")]
        [InlineData ("\"x1.234\" + input Name", "x1.234somevalue2")]
        public void EvaluateExpression_String_Plus (string exprText, string expected) {
            var inputDict = new Dictionary<string, Variable> () { { "item1", "somevalue" }, { "input Name", "somevalue2" } };
            Variable variable = ParseAndEval (exprText, new VariableContext () { InputNameDict = inputDict });
            Assert.Equal<string> (expected, variable);

        }

        [Theory]
        [InlineData ("1+2", 3)]
        [InlineData ("1+1", 2)]
        [InlineData ("1000 + 2000", 3000)]
        [InlineData ("1.1 + 2.1", 3.2)]
        [InlineData ("2 + (3 * 3)", 11)]
        [InlineData ("2 + 3 * 3", 11)]
        [InlineData ("0 - 1", -1)]
        [InlineData ("3-1", 2)]
        [InlineData ("3 * 1", 3)]
        [InlineData ("1*1", 1)]
        [InlineData ("3.1*2", 6.2)]
        [InlineData ("3 / 1", 3)]
        [InlineData ("1 / 1", 1)]
        [InlineData ("6.2/2", 3.1)]
        [InlineData ("-(-3)", 3)]
        [InlineData ("-3", -3)]
        [InlineData ("-10+-5", -15)]
        [InlineData ("(-10)+(-5)", -15)]
        public void EvaluationExpression_Math_Numeric (string exprText, decimal expected) {

            Variable variable = ParseAndEval (exprText);

            Assert.Equal<decimal> (expected, variable);
        }

        private Variable ParseAndEval (string exprText, VariableContext context = null) {
            if (context == null) {
                context = new VariableContext ();
            }

            var eval = new Evaluation ();
            var variable = eval.EvaluateExpressionsBase (exprText, context);
            return variable;
        }
    }
}