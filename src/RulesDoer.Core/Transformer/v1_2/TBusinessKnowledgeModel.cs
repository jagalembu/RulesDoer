namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tBusinessKnowledgeModel", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("businessKnowledgeModel", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TBusinessKnowledgeModel : TInvocable {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("encapsulatedLogic", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TFunctionDefinition EncapsulatedLogic { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TKnowledgeRequirement> _knowledgeRequirement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("knowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TKnowledgeRequirement> KnowledgeRequirement {
            get {
                return this._knowledgeRequirement;
            }
            private set {
                this._knowledgeRequirement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die KnowledgeRequirement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the KnowledgeRequirement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool KnowledgeRequirementSpecified {
            get {
                return (this.KnowledgeRequirement.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TBusinessKnowledgeModel" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TBusinessKnowledgeModel" /> class.</para>
        /// </summary>
        public TBusinessKnowledgeModel () {
            this._knowledgeRequirement = new System.Collections.ObjectModel.Collection<TKnowledgeRequirement> ();
            this._authorityRequirement = new System.Collections.ObjectModel.Collection<TAuthorityRequirement> ();
        }

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
    }
}