using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tAuthorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TAuthorityRequirement {

        [XmlElement ("requiredDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredDecision { get; set; }

        [XmlElement ("requiredInput", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredInput { get; set; }

        [XmlElement ("requiredAuthority", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredAuthority { get; set; }
    }
}