using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tOutputClause", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TOutputClause : TDMNElement {

        [XmlElement ("outputValues", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TUnaryTests OutputValues { get; set; }

        [XmlElement ("defaultOutputEntry", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TLiteralExpression DefaultOutputEntry { get; set; }

        [XmlAttribute ("name", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string Name { get; set; }

        [XmlAttribute ("typeRef", Form = XmlSchemaForm.Unqualified, DataType = "QName")]
        public System.Xml.XmlQualifiedName TypeRef { get; set; }
    }
}