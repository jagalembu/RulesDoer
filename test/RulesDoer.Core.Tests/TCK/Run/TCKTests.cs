using Microsoft.Extensions.Logging;
using Moq;
using RulesDoer.Core.Tests.TCK.Transformer;
using Xunit;

namespace RulesDoer.Core.Tests.TCK.Run {
    public class TCKTests : IClassFixture<DMNFixture> {
        private readonly DMNFixture _fixture;

        public TCKTests (DMNFixture fixture) {
            _fixture = fixture;
        }

        [Theory]
        [RuleFile ("DmnFiles.TCK.compliance_level_2._0001_input_data_string.0001-input-data-string-test-01.xml")]
        public void Compliance_Level_2 (string inputTckXml) {

            var mockLogTrans = new Mock<ILogger<TCKTransformer>> ();
            ILogger<TCKTransformer> loggerTransfomer = mockLogTrans.Object;
            var tckTransformer = new TCKTransformer (loggerTransfomer);

            var executeTCK = new ExecuteTCK (_fixture._dmnDoer, tckTransformer);

            executeTCK.RunTest (inputTckXml);

        }

    }
}