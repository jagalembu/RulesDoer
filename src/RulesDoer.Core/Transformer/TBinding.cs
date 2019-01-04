using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tBinding", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TBinding {

        [XmlElement ("parameter", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TInformationItem Parameter { get; set; }

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TExpression Expression { get; set; }
    }
}