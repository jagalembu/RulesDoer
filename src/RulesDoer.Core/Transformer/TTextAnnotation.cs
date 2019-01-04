using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tTextAnnotation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("textAnnotation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TTextAnnotation : TArtifact {

        [XmlElement ("text", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string Text { get; set; }

        [XmlAttribute ("textFormat", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string TextFormat { get; set; } = "text/plain";
    }
}