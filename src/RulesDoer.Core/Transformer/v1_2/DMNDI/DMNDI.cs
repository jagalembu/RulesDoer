namespace RulesDoer.Core.Transformer.v1_2.DMNDI {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("DMNDI", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("DMNDI", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    public partial class DMNDIModel {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<DMNDiagram> _dMNDiagram;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("DMNDiagram", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public System.Collections.ObjectModel.Collection<DMNDiagram> DMNDiagram {
            get {
                return this._dMNDiagram;
            }
            private set {
                this._dMNDiagram = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DMNDiagram-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DMNDiagram collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DMNDiagramSpecified {
            get {
                return (this.DMNDiagram.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="DMNDI" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DMNDI" /> class.</para>
        /// </summary>
        public DMNDIModel () {
            this._dMNDiagram = new System.Collections.ObjectModel.Collection<DMNDiagram> ();
            this._dMNStyle = new System.Collections.ObjectModel.Collection<DMNStyle> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<DMNStyle> _dMNStyle;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("DMNStyle", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public System.Collections.ObjectModel.Collection<DMNStyle> DMNStyle {
            get {
                return this._dMNStyle;
            }
            private set {
                this._dMNStyle = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DMNStyle-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DMNStyle collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DMNStyleSpecified {
            get {
                return (this.DMNStyle.Count != 0);
            }
        }
    }
}