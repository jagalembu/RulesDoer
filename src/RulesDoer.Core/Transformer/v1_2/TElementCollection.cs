namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tElementCollection", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("elementCollection", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TElementCollection : TNamedElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _drgElement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("drgElement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> DrgElement {
            get {
                return this._drgElement;
            }
            private set {
                this._drgElement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DrgElement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DrgElement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DrgElementSpecified {
            get {
                return (this.DrgElement.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TElementCollection" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TElementCollection" /> class.</para>
        /// </summary>
        public TElementCollection () {
            this._drgElement = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
        }
    }
}