namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tBusinessContextElement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("businessContextElement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TOrganizationUnit))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TPerformanceIndicator))]
    public partial class TBusinessContextElement : TNamedElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("URI", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string URI { get; set; }
    }
}