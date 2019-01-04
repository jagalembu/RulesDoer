using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tUnaryTests", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TUnaryTests : TDMNElement {

        [XmlElement ("text", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string Text { get; set; }

        [XmlAttribute ("expressionLanguage", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string ExpressionLanguage { get; set; }
    }
}