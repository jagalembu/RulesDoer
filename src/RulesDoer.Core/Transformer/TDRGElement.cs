using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDRGElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("drgElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TBusinessKnowledgeModel))]
    [XmlInclude (typeof (TDecision))]
    [XmlInclude (typeof (TInputData))]
    [XmlInclude (typeof (TKnowledgeSource))]
    public partial class TDRGElement : TNamedElement { }
}