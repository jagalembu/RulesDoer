namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("tDMNElement", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("DMNElement", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TArtifact))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TAssociation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TAuthorityRequirement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TBusinessContextElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TBusinessKnowledgeModel))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TContext))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TContextEntry))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecision))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecisionRule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecisionService))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDecisionTable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDefinitions))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TDRGElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TElementCollection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TExpression))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TFunctionDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TImport))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TImportedValues))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInformationItem))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInformationRequirement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInputClause))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInputData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInvocable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TInvocation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TItemDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TKnowledgeRequirement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TKnowledgeSource))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TList))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TLiteralExpression))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TNamedElement))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TOrganizationUnit))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TOutputClause))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TPerformanceIndicator))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TRelation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TTextAnnotation))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TUnaryTests))]
    public partial class TDMNElement
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("description", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string Description { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("extensionElements", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementExtensionElements ExtensionElements { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("id", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("label", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Label { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> _anyAttribute;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> AnyAttribute
        {
            get
            {
                return this._anyAttribute;
            }
            private set
            {
                this._anyAttribute = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDMNElement" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDMNElement" /> class.</para>
        /// </summary>
        public TDMNElement()
        {
            this._anyAttribute = new System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute>();
        }
    }
}