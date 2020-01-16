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
        [TCKFiles ("compliance_level_2.")]
        public void Compliance_Level_2 (string filename, string inputTckXml) {

            var mockLogTrans = new Mock<ILogger<TCKTransformer>> ();
            ILogger<TCKTransformer> loggerTransfomer = mockLogTrans.Object;
            var tckTransformer = new TCKTransformer (loggerTransfomer);

            var executeTCK = new ExecuteTCK (_fixture._dmnDoer, tckTransformer);

            executeTCK.RunTest (filename, inputTckXml);

        }

        //0004 - lending
        //0014 - loan
        //0020 - vacation
        //0034 - drg
        //0037 - dt
        //0038 - dt
        //0075 - java test - need to check
        //0076 - external java - need to exclude
        //0082 - feel coercion
        //0085 - decision service
        //0086 - import - need the feature for imports
        //0087 - chapter 11 test - bug cannot recognize semantic stuff - missing xml mapping
        [Theory]
        [TCKFiles ("compliance_level_3.")]
        public void Compliance_Level_3 (string filename, string inputTckXml) {

            var mockLogTrans = new Mock<ILogger<TCKTransformer>> ();
            ILogger<TCKTransformer> loggerTransfomer = mockLogTrans.Object;
            var tckTransformer = new TCKTransformer (loggerTransfomer);

            var executeTCK = new ExecuteTCK (_fixture._dmnDoer, tckTransformer);

            //executeTCK.RunTest (filename, inputTckXml, "conditionWithFunctions");
            executeTCK.RunTest (filename, inputTckXml);

        }

        [Theory]
        [TCKFiles ("non_compliant._0015")]
        public void Non_Compliant (string filename, string inputTckXml) {

            var mockLogTrans = new Mock<ILogger<TCKTransformer>> ();
            ILogger<TCKTransformer> loggerTransfomer = mockLogTrans.Object;
            var tckTransformer = new TCKTransformer (loggerTransfomer);

            var executeTCK = new ExecuteTCK (_fixture._dmnDoer, tckTransformer);

            executeTCK.RunTest (filename, inputTckXml);

        }

    }
}