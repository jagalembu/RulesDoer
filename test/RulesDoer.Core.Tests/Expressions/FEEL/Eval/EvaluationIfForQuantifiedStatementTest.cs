using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using Xunit;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class EvaluationIfForQuantifiedStatementTest {
        [Theory]
        [InlineData ("if true then 5 else 10", null, 5, null)]
        [InlineData ("if false then 5 else 10", null, 10, null)]
        [InlineData ("if true then \"x\" else \"y\"", "x", 10, null)]
        [InlineData ("if false then \"x\" else \"y\"", "y", 10, null)]
        public void EvaluateIfStatement (string exprText, string expectedStr, int? expectedInt, bool? expectedBool) {
            VariableContext context = new VariableContext ();

            Variable variable = ParseAndEval (exprText, context);
            if (!string.IsNullOrWhiteSpace (expectedStr)) {
                Assert.Equal(expectedStr, variable);
            } else if (expectedBool.HasValue) {
                Assert.Equal<bool> (expectedBool.Value, variable);
            } else if (expectedInt.HasValue) {
                Assert.Equal<int> (expectedInt.Value, (int) variable.NumericVal);
            }

        }

        [Theory]
        [ClassData (typeof (ForDataTests))]
        public void EvaluateForStatement (string exprText, Variable expected) {
            VariableContext context = new VariableContext ();

            Variable variable = ParseAndEval (exprText, context);

            Assert.True (variable.Equals (expected));

        }

        [Theory]
        [InlineData ("some x in [1..2], y in [2..3] satisfies x + y > 5", false)]
        [InlineData ("some x in [1..2], y in [2..3] satisfies x + y > 4", true)]
        [InlineData ("every x in [1..2], y in [2..3] satisfies x + y > 1", true)]
        [InlineData ("every x in [1..2], y in [2..3] satisfies x + y > 4", false)]
        public void EvaluateQuantifiedStatement (string exprText, bool expectedBool) {
            VariableContext context = new VariableContext ();

            Variable variable = ParseAndEval (exprText, context);

            Assert.Equal<bool> (expectedBool, variable);
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