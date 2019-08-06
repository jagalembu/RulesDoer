namespace RulesDoer.Core.Tests.TCK.Transformer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("TestCasesLabels", Namespace="http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestCasesLabels
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _label;
        
        [System.Xml.Serialization.XmlElementAttribute("label", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<string> Label
        {
            get
            {
                return this._label;
            }
            private set
            {
                this._label = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LabelSpecified
        {
            get
            {
                return (this.Label.Count != 0);
            }
        }
        
        public TestCasesLabels()
        {
            this._label = new System.Collections.ObjectModel.Collection<string>();
        }
    }
}