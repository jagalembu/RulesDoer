using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Serialization {
    public class DMNTransformer {
        private readonly ILogger<DMNTransformer> _logger;
        private List<string> _errorList = new List<string> ();
        public DMNTransformer (ILogger<DMNTransformer> logger) {
            _logger = logger;
        }

        public TDefinitions Transform (string dmn) {

            TDefinitions def;
            using (var reader = new StringReader (dmn)) {
                var xmlSerializer = new XmlSerializer (typeof (TDefinitions));

                xmlSerializer.UnknownAttribute +=
                    new XmlAttributeEventHandler (Serializer_UnknownAttributeEvent);
                xmlSerializer.UnknownElement +=
                    new XmlElementEventHandler (Serializer_UnknownElementEvent);
                xmlSerializer.UnknownNode +=
                    new XmlNodeEventHandler (Serializer_UnknownNodeEvent);

                def = (TDefinitions) xmlSerializer.Deserialize (reader);
            }

            if (_errorList.Count > 0) {
                throw new DMNException ("Failed reading the dmn definition");
            }

            return def;
        }

        public string Transform (TDefinitions definitions) {
            var xmlSerializer = new XmlSerializer (typeof (TDefinitions));
            var dmnWriter = new StringWriter ();

            xmlSerializer.Serialize (dmnWriter, definitions);

            return dmnWriter.ToString ();
        }

        private void Serializer_UnknownAttributeEvent (object sender, XmlAttributeEventArgs e) {
            var errTxt = $"Unknown Attribute {e.Attr.Name} {e.Attr.InnerXml}. Line number:{e.LineNumber} Line Position: {e.LinePosition} ";
            _logger.LogError (errTxt);
            _errorList.Add (errTxt);
        }
        private void Serializer_UnknownElementEvent (object sender, XmlElementEventArgs e) {
            var errTxt = $"Unknown Element {e.Element.Name} {e.Element.InnerXml}. Line number:{e.LineNumber} Line Position: {e.LinePosition} ";
            _logger.LogError (errTxt);
            _errorList.Add (errTxt);
        }

        private void Serializer_UnknownNodeEvent (object sender, XmlNodeEventArgs e) {
            var errTxt = $"Unknown Node Name: {e.Name}  LocalName: {e.LocalName} Namespace:{e.NamespaceURI} Text: {e.Text} ";
            _logger.LogError (errTxt);
            _errorList.Add (errTxt);

        }

    }
}