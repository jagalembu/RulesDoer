namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tKnowledgeSource", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("knowledgeSource", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TKnowledgeSource : TDRGElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TAuthorityRequirement> _authorityRequirement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TAuthorityRequirement> AuthorityRequirement {
            get {
                return this._authorityRequirement;
            }
            private set {
                this._authorityRequirement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die AuthorityRequirement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the AuthorityRequirement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool AuthorityRequirementSpecified {
            get {
                return (this.AuthorityRequirement.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TKnowledgeSource" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TKnowledgeSource" /> class.</para>
        /// </summary>
        public TKnowledgeSource () {
            this._authorityRequirement = new System.Collections.ObjectModel.Collection<TAuthorityRequirement> ();
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("type", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("owner", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference Owner { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("locationURI", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string LocationURI { get; set; }
    }
}