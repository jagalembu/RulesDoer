using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tNamedElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("namedElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TBusinessContextElement))]
    [XmlInclude (typeof (TBusinessKnowledgeModel))]
    [XmlInclude (typeof (TDecision))]
    [XmlInclude (typeof (TDecisionService))]
    [XmlInclude (typeof (TDefinitions))]
    [XmlInclude (typeof (TDRGElement))]
    [XmlInclude (typeof (TElementCollection))]
    [XmlInclude (typeof (TInformationItem))]
    [XmlInclude (typeof (TInputData))]
    [XmlInclude (typeof (TItemDefinition))]
    [XmlInclude (typeof (TKnowledgeSource))]
    [XmlInclude (typeof (TOrganizationUnit))]
    [XmlInclude (typeof (TPerformanceIndicator))]
    public partial class TNamedElement : TDMNElement {

        [XmlAttribute ("name", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string Name { get; set; }
    }
}