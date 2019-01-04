using System;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDMNElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("DMNElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TArtifact))]
    [XmlInclude (typeof (TAssociation))]
    [XmlInclude (typeof (TBusinessContextElement))]
    [XmlInclude (typeof (TBusinessKnowledgeModel))]
    [XmlInclude (typeof (TContext))]
    [XmlInclude (typeof (TDecision))]
    [XmlInclude (typeof (TDecisionRule))]
    [XmlInclude (typeof (TDecisionService))]
    [XmlInclude (typeof (TDecisionTable))]
    [XmlInclude (typeof (TDefinitions))]
    [XmlInclude (typeof (TDRGElement))]
    [XmlInclude (typeof (TElementCollection))]
    [XmlInclude (typeof (TExpression))]
    [XmlInclude (typeof (TFunctionDefinition))]
    [XmlInclude (typeof (TInformationItem))]
    [XmlInclude (typeof (TInputClause))]
    [XmlInclude (typeof (TInputData))]
    [XmlInclude (typeof (TInvocation))]
    [XmlInclude (typeof (TItemDefinition))]
    [XmlInclude (typeof (TKnowledgeSource))]
    [XmlInclude (typeof (TList))]
    [XmlInclude (typeof (TLiteralExpression))]
    [XmlInclude (typeof (TNamedElement))]
    [XmlInclude (typeof (TOrganizationUnit))]
    [XmlInclude (typeof (TOutputClause))]
    [XmlInclude (typeof (TPerformanceIndicator))]
    [XmlInclude (typeof (TRelation))]
    [XmlInclude (typeof (TTextAnnotation))]
    [XmlInclude (typeof (TUnaryTests))]
    public partial class TDMNElement {

        [XmlElement ("description", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string Description { get; set; }

        [XmlElement ("extensionElements", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementExtensionElements ExtensionElements { get; set; }

        [XmlAttribute ("id", Form = XmlSchemaForm.Unqualified, DataType = "ID")]
        public string Id { get; set; }

        [XmlAttribute ("label", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string Label { get; set; }

        [XmlAnyAttribute]
        public Collection<XmlAttribute> AnyAttribute { get; set; }

    }
}