using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using Xunit;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class EvaluationSimpleUnaryTestsBaseTests {

        [Theory]
        [InlineData ("1", "number", true)]
        [InlineData ("2", "number", false)]
        [InlineData ("1,2", "number", true)]
        [InlineData ("2,3", "number", false)]
        [InlineData ("\"abc\"", "stringval", true)]
        [InlineData ("\"kfc\"", "stringval", false)]
        [InlineData ("\"abc\",\"kfc\"", "stringval", true)]
        [InlineData ("\"vol\",\"kfc\"", "stringval", false)]
        public void Evaluate_Operator_Equal (string exprText, string inputName, bool expected) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "number", 1 }, { "stringval", "abc" } };

            var variable = ParseAndEval (exprText, context, inputName);
            Assert.Equal<bool> (expected, variable);
        }

        [Theory]
        [InlineData ("not(1)", "number", false)]
        [InlineData ("not(2)", "number", true)]
        [InlineData ("not(\"kfc\")", "stringval", true)]
        [InlineData ("not(\"abc\")", "stringval", false)]
        public void Evaluate_Not (string exprText, string inputName, bool expected) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "number", 1 }, { "stringval", "abc" } };

            var variable = ParseAndEval (exprText, context, inputName);
            Assert.Equal<bool> (expected, variable);
        }

        [Theory]
        [InlineData ("-", "number", true)]
        [InlineData ("-", "stringval", true)]
        public void Evaluate_Any (string exprText, string inputName, bool expected) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "number", 1 }, { "stringval", "abc" } };

            var variable = ParseAndEval (exprText, context, inputName);
            Assert.Equal<bool> (expected, variable);
        }

        [Theory]
        [InlineData ("[0..1]", "number", true)]
        [InlineData ("[1..1]", "number", true)]
        [InlineData ("(0..2)", "number", true)]
        [InlineData ("(0..1)", "number", false)]
        [InlineData ("(0..1]", "number", true)]
        [InlineData ("(0..0]", "number", false)]
        [InlineData ("[1..2)", "number", true )]
        [InlineData ("[1..1)", "number", false )]
        public void Evaluate_Interval (string exprText, string inputName, bool expected) {
            VariableContext context = new VariableContext ();
            context.InputNameDict = new Dictionary<string, Variable> () { { "number", 1 }, { "stringval", "abc" } };

            var variable = ParseAndEval (exprText, context, inputName);
            Assert.Equal<bool> (expected, variable);
        }

        private bool ParseAndEval (string exprText, VariableContext context, string inputName) {
            var eval = new Evaluation (context, inputName);
            var boolVal = eval.EvaluateSimpleUnaryTestsBase (exprText);
            return boolVal;
        }
    }
}