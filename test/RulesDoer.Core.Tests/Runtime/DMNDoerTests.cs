using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using Xunit;

namespace RulesDoer.Core.Tests.Runtime {
    public class DMNDoerTests : IClassFixture<DMNFixture> {
        private readonly DMNFixture _fixture;

        public DMNDoerTests (DMNFixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void EvaluateDecisions_Decision_With_LiteralExpression_NoInputs () {
            var rslt = _fixture._dmnDoer.EvaluateDecisions (new VariableContext (), "decision-litexpr-noinput");
            rslt.TryGetValue ("Decision1", out var decisionRslt);
            Assert.NotNull (decisionRslt);
            Assert.Equal ("foo bar", decisionRslt);
        }

        [Fact]
        public void EvaluateDecisions_Decision_With_LiteralExpression_And_Input () {
            var rslt = _fixture._dmnDoer.EvaluateDecisions (new VariableContext () { InputNameDict = new Dictionary<string, Variable> () { { "Full Name", "some dude" } } }, "0001-input-data-string");
            rslt.TryGetValue ("Greeting Message", out var decisionRslt);
            Assert.NotNull (decisionRslt);
            Assert.Equal ("Hello some dude", decisionRslt);
        }

        [Fact]
        public void EvaluateDecisions_DecisionTable_Unique () {
            var rslt = _fixture._dmnDoer.EvaluateDecisions (new VariableContext () { InputNameDict = new Dictionary<string, Variable> () { { "Age", 18 }, { "RiskCategory", "Medium" }, { "isAffordable", true } } }, "0004-simpletable-U");
            rslt.TryGetValue ("Approval Status", out var decisionRslt);
            Assert.NotNull (decisionRslt);
            DecisionTableResult tRslt = decisionRslt;
            Assert.NotNull (tRslt);
            Assert.NotNull (tRslt.OutputResult);
            Assert.Equal (1, tRslt.OutputResult.Count);

            var actualValues = tRslt.OutputResult[0].Values;

            foreach (var item in actualValues) {
                Assert.Equal<string> ("Approved", item);
            }

        }

    }
}