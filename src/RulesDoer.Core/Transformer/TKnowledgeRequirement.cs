using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tKnowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TKnowledgeRequirement {

        [XmlElement ("requiredKnowledge", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference RequiredKnowledge { get; set; }
    }
}