using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tInputClause", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TInputClause : TDMNElement {

        [XmlElement ("inputExpression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TLiteralExpression InputExpression { get; set; }

        [XmlElement ("inputValues", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TUnaryTests InputValues { get; set; }
    }
}