using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tInformationRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TInformationRequirement {

        [XmlElement ("requiredDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredDecision { get; set; }

        [XmlElement ("requiredInput", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredInput { get; set; }
    }
}