using System;
using Microsoft.Extensions.Logging;
using Moq;
using RulesDoer.Core.Serialization;
using RulesDoer.Core.Transformer.v1_2;
using Xunit;

namespace RulesDoer.Core.Tests.Serialization {
    public class DMNTransformerTests {
        [Fact]
        public void Tranform_ModelToString () {
            var mock = new Mock<ILogger<DMNTransformer>> ();
            ILogger<DMNTransformer> logger = mock.Object;
            var dmnTranformer = new DMNTransformer (logger);
            var definitions = new TDefinitions { Name = "test" };
            var actual = dmnTranformer.Transform (definitions);
        }

        [Theory]
        [RuleFile ("Serialization.Files.empty.dmn")]
        public void Transform_ToModel_EmptyFile (string inputRule) {
            var mock = new Mock<ILogger<DMNTransformer>> ();
            ILogger<DMNTransformer> logger = mock.Object;
            var dmnTransformer = new DMNTransformer (logger);
            Assert.Throws<InvalidOperationException> (() => dmnTransformer.Transform (inputRule));
        }

        [Theory]
        [RuleFile ("Serialization.Files.inputdatastring.dmn")]
        public void Transform_ToModel_InputDataString (string inputRule) {
            var mock = new Mock<ILogger<DMNTransformer>> ();
            ILogger<DMNTransformer> logger = mock.Object;
            var dmnTransformer = new DMNTransformer (logger);
            var actual = dmnTransformer.Transform (inputRule);
        }
    }
}