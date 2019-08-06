namespace RulesDoer.Core.Tests.TCK.Transformer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("TestCasesTestCaseExtensionElements", Namespace="http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestCasesTestCaseExtensionElements
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return this._any;
            }
            private set
            {
                this._any = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnySpecified
        {
            get
            {
                return (this.Any.Count != 0);
            }
        }
        
        public TestCasesTestCaseExtensionElements()
        {
            this._any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
}