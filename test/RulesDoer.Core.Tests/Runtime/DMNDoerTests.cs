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

    }
}