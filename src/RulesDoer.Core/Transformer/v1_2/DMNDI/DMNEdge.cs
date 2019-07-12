using RulesDoer.Core.Transformer.v1_2.DI;

namespace RulesDoer.Core.Transformer.v1_2.DMNDI
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DMNEdge", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("DMNEdge", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    public partial class DMNEdge : Edge
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("DMNLabel", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public DMNLabel DMNLabel { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("dmnElementRef", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Xml.XmlQualifiedName DmnElementRef { get; set; }
    }
}