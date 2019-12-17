using System.Xml;
using System.Xml.Serialization;

namespace RulesDoer.Core.Tests.TCK.Transformer {
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("valueType", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TestCasesTestCaseInputNode))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (ValueTypeComponent))]
    public partial class ValueType {

        [System.Xml.Serialization.XmlElementAttribute ("value",  Namespace = "http://www.omg.org/spec/DMN/20160719/testcase", IsNullable=true)]
        public Value Value { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<ValueTypeComponent> _component;

        [System.Xml.Serialization.XmlElementAttribute ("component", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase", IsNullable = true)]
        public System.Collections.ObjectModel.Collection<ValueTypeComponent> Component {
            get {
                return this._component;
            }
            private set {
                this._component = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ComponentSpecified {
            get {
                return (this.Component.Count != 0);
            }
        }

        public ValueType () {
            this._component = new System.Collections.ObjectModel.Collection<ValueTypeComponent> ();
            this._list = new System.Collections.ObjectModel.Collection<ValueType> ();
            this._anyAttribute = new System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<ValueType> _list;

        [System.Xml.Serialization.XmlArrayAttribute ("list", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase", IsNullable = true)]
        [System.Xml.Serialization.XmlArrayItemAttribute ("item", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<ValueType> List {
            get {
                return this._list;
            }
            private set {
                this._list = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ListSpecified {
            get {
                return (this.List.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlElementAttribute ("extensionElements", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
        public ValueTypeExtensionElements ExtensionElements { get; set; }

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