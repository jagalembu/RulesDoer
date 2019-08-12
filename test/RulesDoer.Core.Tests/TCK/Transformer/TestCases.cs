namespace RulesDoer.Core.Tests.TCK.Transformer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("testCases", Namespace="http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("testCases", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
    public partial class TestCases
    {
        [System.Xml.Serialization.XmlAttributeAttribute("schemaLocation", Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
               
        [System.Xml.Serialization.XmlElementAttribute("modelName", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public string ModelName { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<string> _labels;
        
        [System.Xml.Serialization.XmlArrayAttribute("labels", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        [System.Xml.Serialization.XmlArrayItemAttribute("label", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<string> Labels
        {
            get
            {
                return this._labels;
            }
            private set
            {
                this._labels = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LabelsSpecified
        {
            get
            {
                return (this.Labels.Count != 0);
            }
        }
        
        public TestCases()
        {
            this._labels = new System.Collections.ObjectModel.Collection<string>();
            this._testCase = new System.Collections.ObjectModel.Collection<TestCasesTestCase>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<TestCasesTestCase> _testCase;
        
        [System.Xml.Serialization.XmlElementAttribute("testCase", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<TestCasesTestCase> TestCase
        {
            get
            {
                return this._testCase;
            }
            private set
            {
                this._testCase = value;
            }
        }
    }
}