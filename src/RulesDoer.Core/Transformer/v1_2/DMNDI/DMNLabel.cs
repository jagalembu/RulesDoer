using RulesDoer.Core.Transformer.v1_2.DI;

namespace RulesDoer.Core.Transformer.v1_2.DMNDI
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DMNLabel", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("DMNLabel", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    public partial class DMNLabel : Shape
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("Text", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public string Text { get; set; }
    }
}