using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using Xunit;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval
{

    public class EvaluationSimpleExpressionsTest {

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

            Assert.Equal(expected, variable);

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
            var variable = eval.EvaluateSimpleExpressionsBase (exprText, context);
            return variable;
        }

    }

}