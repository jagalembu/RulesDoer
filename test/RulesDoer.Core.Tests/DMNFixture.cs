using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Repo;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Serialization;
using RulesDoer.Core.Validation;

namespace RulesDoer.Core.Tests {
    public class DMNFixture {
        public readonly DefaultDMNPersistence _dmnPersistence;
        public readonly DMNRepository _dmnRepository;
        public readonly DMNDefaultValidation _dmnValidation;
        public readonly DMNTransformer _dmnTransformer;

        public readonly DMNDoer _dmnDoer;

        public DMNFixture () {
            _dmnPersistence = DefaultDMNPersistence.Instance;

            var assembly = Assembly.GetExecutingAssembly ();
            var resourceNames = assembly.GetManifestResourceNames ();

            string xmlContent;
            foreach (var resourceName in resourceNames) {
                if (resourceName.Contains ("DmnFiles")) {
                    var resourceStream = assembly.GetManifestResourceStream (resourceName);

                    using (TextReader textReader = new StreamReader (resourceStream, Encoding.UTF8)) {
                        xmlContent = textReader.ReadToEnd ();
                    }

                    var splitNames = resourceName.Split ('.');

                    _dmnPersistence.WriteDefinitions (splitNames[splitNames.Length - 2], xmlContent);

                }
            }

            var mockLogTrans = new Mock<ILogger<DMNTransformer>> ();
            ILogger<DMNTransformer> loggerTransfomer = mockLogTrans.Object;
            _dmnTransformer = new DMNTransformer (loggerTransfomer);

            var mockLogVal = new Mock<ILogger<DMNDefaultValidation>> ();
            ILogger<DMNDefaultValidation> loggerValidation = mockLogVal.Object;
            _dmnValidation = new DMNDefaultValidation (loggerValidation);

            _dmnRepository = new DMNRepository (_dmnTransformer, _dmnPersistence, _dmnValidation);

            _dmnDoer = new DMNDoer (new Evaluation (), _dmnRepository);

        }

    }
}