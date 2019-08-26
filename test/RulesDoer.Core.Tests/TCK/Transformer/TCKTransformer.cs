using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;

namespace RulesDoer.Core.Tests.TCK.Transformer {
    public class TCKTransformer {
        private readonly ILogger<TCKTransformer> _logger;
        private List<string> _errorList = new List<string> ();
        public TCKTransformer (ILogger<TCKTransformer> logger) {
            _logger = logger;
        }

        public TestCases Transform (string xml) {

            _errorList.Clear ();

            TestCases def;
            var setttings = new XmlReaderSettings ();
            setttings.IgnoreWhitespace = false;
            using (var mem = new MemoryStream (Encoding.UTF8.GetBytes (xml)))
            using (var xmlR = XmlReader.Create (mem, setttings)) {
                var xmlSerializer = new XmlSerializer (typeof (TestCases));

                xmlSerializer.UnknownAttribute +=
                    new XmlAttributeEventHandler (Serializer_UnknownAttributeEvent);
                xmlSerializer.UnknownElement +=
                    new XmlElementEventHandler (Serializer_UnknownElementEvent);
                xmlSerializer.UnknownNode +=
                    new XmlNodeEventHandler (Serializer_UnknownNodeEvent);

                def = (TestCases) xmlSerializer.Deserialize (xmlR);
            }

            if (_errorList.Count > 0) {
                throw new TCKException ("Failed reading the tck definition");
            }

            return def;
        }

        public string Transform (TestCases definitions) {
            var xmlSerializer = new XmlSerializer (typeof (TestCases));
            var tckWriter = new StringWriter ();

            xmlSerializer.Serialize (tckWriter, definitions);

            return tckWriter.ToString ();
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