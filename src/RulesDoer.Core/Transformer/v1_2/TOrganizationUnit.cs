namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tOrganizationUnit", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("organizationUnit", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]

    public partial class TOrganizationUnit : TBusinessContextElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _decisionMade;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("decisionMade", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> DecisionMade {
            get {
                return this._decisionMade;
            }
            private set {
                this._decisionMade = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DecisionMade-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DecisionMade collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DecisionMadeSpecified {
            get {
                return (this.DecisionMade.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TOrganizationUnit" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TOrganizationUnit" /> class.</para>
        /// </summary>
        public TOrganizationUnit () {
            this._decisionMade = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._decisionOwned = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _decisionOwned;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("decisionOwned", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> DecisionOwned {
            get {
                return this._decisionOwned;
            }
            private set {
                this._decisionOwned = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DecisionOwned-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DecisionOwned collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DecisionOwnedSpecified {
            get {
                return (this.DecisionOwned.Count != 0);
            }
        }
    }
}