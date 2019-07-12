namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("tImport", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("import", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TImportedValues))]
    public partial class TImport : TNamedElement
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("namespace", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Namespace { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("locationURI", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LocationURI { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("importType", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ImportType { get; set; }
    }
}