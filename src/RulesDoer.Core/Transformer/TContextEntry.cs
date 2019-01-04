using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tContextEntry", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TContextEntry {

        [XmlElement ("variable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TInformationItem Variable { get; set; }

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TExpression Expression { get; set; }
    }
}