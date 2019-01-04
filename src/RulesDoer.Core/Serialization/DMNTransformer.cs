using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using RulesDoer.Core.Transformer;

namespace RulesDoer.Core.Serialization {
    public class DMNTransformer {
        private readonly ILogger<DMNTransformer> _logger;
        public DMNTransformer (ILogger<DMNTransformer> logger) {
            _logger = logger;
        }

        public TDefinitions Transform (string dmn) {

            var xmlSerializer = new XmlSerializer (typeof (TDefinitions));

            return (TDefinitions) xmlSerializer.Deserialize (new StringReader (dmn));

            // var dmnXmlReader = XmlReader.Create(new StringReader(dmn))

        }

        public string Transform (TDefinitions definitions) {
            var xmlSerializer = new XmlSerializer (typeof (TDefinitions));
            var dmnWriter = new StringWriter ();

            xmlSerializer.Serialize (dmnWriter, definitions);

            return dmnWriter.ToString ();
        }
    }
}