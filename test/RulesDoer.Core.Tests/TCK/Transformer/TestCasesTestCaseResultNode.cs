namespace RulesDoer.Core.Tests.TCK.Transformer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("TestCasesTestCaseResultNode", Namespace="http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestCasesTestCaseResultNode
    {
        
        [System.Xml.Serialization.XmlElementAttribute("computed", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public ValueType Computed { get; set; }
        
        [System.Xml.Serialization.XmlElementAttribute("expected", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public ValueType Expected { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private bool _errorResult = false;
        
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.Xml.Serialization.XmlAttributeAttribute("errorResult", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool ErrorResult
        {
            get
            {
                return this._errorResult;
            }
            set
            {
                this._errorResult = value;
            }
        }
        
        [System.Xml.Serialization.XmlAttributeAttribute("name", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("type", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Type { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute("cast", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Cast { get; set; }
    }
}