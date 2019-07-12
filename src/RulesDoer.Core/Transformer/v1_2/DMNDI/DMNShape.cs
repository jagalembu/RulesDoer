using RulesDoer.Core.Transformer.v1_2.DI;

namespace RulesDoer.Core.Transformer.v1_2.DMNDI
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DMNShape", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("DMNShape", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]

    public partial class DMNShape : Shape
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("DMNLabel", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public DMNLabel DMNLabel { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("DMNDecisionServiceDividerLine", Namespace="http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public DMNDecisionServiceDividerLine DMNDecisionServiceDividerLine { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("dmnElementRef", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public System.Xml.XmlQualifiedName DmnElementRef { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("isListedInputData", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool IsListedInputData { get; set; }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die IsListedInputData-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the IsListedInputData property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsListedInputDataSpecified { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private bool _isCollapsed = false;
        
        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.Xml.Serialization.XmlAttributeAttribute("isCollapsed", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool IsCollapsed
        {
            get
            {
                return this._isCollapsed;
            }
            set
            {
                this._isCollapsed = value;
            }
        }
    }
}