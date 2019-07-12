namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("tNamedElement", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("namedElement", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TBusinessContextElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TBusinessKnowledgeModel))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecision))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecisionService))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDefinitions))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDRGElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TElementCollection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TImport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TImportedValues))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInformationItem))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInputData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInvocable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TItemDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TKnowledgeSource))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TOrganizationUnit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TPerformanceIndicator))]
    public partial class TNamedElement : TDMNElement
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
    }
}