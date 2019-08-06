namespace RulesDoer.Core.Tests.TCK.Transformer {
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("TestCasesTestCase", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType = true)]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TestCasesTestCase {

        [System.Xml.Serialization.XmlElementAttribute ("description", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public string Description { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TestCasesTestCaseInputNode> _inputNode;

        [System.Xml.Serialization.XmlElementAttribute ("inputNode", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<TestCasesTestCaseInputNode> InputNode {
            get {
                return this._inputNode;
            }
            private set {
                this._inputNode = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InputNodeSpecified {
            get {
                return (this.InputNode.Count != 0);
            }
        }

        public TestCasesTestCase () {
            this._inputNode = new System.Collections.ObjectModel.Collection<TestCasesTestCaseInputNode> ();
            this._resultNode = new System.Collections.ObjectModel.Collection<TestCasesTestCaseResultNode> ();
            this._anyAttribute = new System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TestCasesTestCaseResultNode> _resultNode;

        [System.Xml.Serialization.XmlElementAttribute ("resultNode", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<TestCasesTestCaseResultNode> ResultNode {
            get {
                return this._resultNode;
            }
            private set {
                this._resultNode = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ResultNodeSpecified {
            get {
                return (this.ResultNode.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlElementAttribute ("extensionElements", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public TestCasesTestCaseExtensionElements ExtensionElements { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute ("id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private TestCaseType _type = TestCaseType.Decision;

        [System.ComponentModel.DefaultValueAttribute (TestCaseType.Decision)]
        [System.Xml.Serialization.XmlAttributeAttribute ("type", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TestCaseType Type {
            get {
                return this._type;
            }
            set {
                this._type = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute ("invocableName", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string InvocableName { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute ("name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> _anyAttribute;

        [System.Xml.Serialization.XmlAnyAttributeAttribute ()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> AnyAttribute {
            get {
                return this._anyAttribute;
            }
            private set {
                this._anyAttribute = value;
            }
        }
    }
}