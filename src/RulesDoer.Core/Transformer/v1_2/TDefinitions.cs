using System.Xml.Serialization;
using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tDefinitions", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("definitions", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TDefinitions : TNamedElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TImport> _import;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("import", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TImport> Import {
            get {
                return this._import;
            }
            private set {
                this._import = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Import-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Import collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ImportSpecified {
            get {
                return (this.Import.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDefinitions" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDefinitions" /> class.</para>
        /// </summary>
        public TDefinitions () {
            this._import = new System.Collections.ObjectModel.Collection<TImport> ();
            this._itemDefinition = new System.Collections.ObjectModel.Collection<TItemDefinition> ();
            this._drgElement = new System.Collections.ObjectModel.Collection<TDRGElement> ();
            this._artifact = new System.Collections.ObjectModel.Collection<TArtifact> ();
            this._elementCollection = new System.Collections.ObjectModel.Collection<TElementCollection> ();
            this._businessContextElement = new System.Collections.ObjectModel.Collection<TBusinessContextElement> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TItemDefinition> _itemDefinition;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("itemDefinition", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TItemDefinition> ItemDefinition {
            get {
                return this._itemDefinition;
            }
            private set {
                this._itemDefinition = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ItemDefinition-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ItemDefinition collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ItemDefinitionSpecified {
            get {
                return (this.ItemDefinition.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDRGElement> _drgElement;

        /// <summary>
        /// </summary>
        [XmlElement ("inputData",typeof(TInputData), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [XmlElement ("decision",typeof(TDecision), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [XmlElement ("businessKnowledgeModel",typeof(TBusinessKnowledgeModel), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [XmlElement ("knowledgeSource",typeof(TKnowledgeSource), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [XmlElement ("decisionService",typeof(TDecisionService), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]                        
        public System.Collections.ObjectModel.Collection<TDRGElement> DrgElement {
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

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TArtifact> _artifact;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("artifact", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TArtifact> Artifact {
            get {
                return this._artifact;
            }
            private set {
                this._artifact = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Artifact-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Artifact collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ArtifactSpecified {
            get {
                return (this.Artifact.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TElementCollection> _elementCollection;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("elementCollection", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TElementCollection> ElementCollection {
            get {
                return this._elementCollection;
            }
            private set {
                this._elementCollection = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ElementCollection-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ElementCollection collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ElementCollectionSpecified {
            get {
                return (this.ElementCollection.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TBusinessContextElement> _businessContextElement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("businessContextElement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TBusinessContextElement> BusinessContextElement {
            get {
                return this._businessContextElement;
            }
            private set {
                this._businessContextElement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die BusinessContextElement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the BusinessContextElement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool BusinessContextElementSpecified {
            get {
                return (this.BusinessContextElement.Count != 0);
            }
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("DMNDI", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public DMNDIModel DMNDI { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private string _expressionLanguage = "http://www.omg.org/spec/DMN/20180521/FEEL/";

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute ("http://www.omg.org/spec/DMN/20180521/FEEL/")]
        [System.Xml.Serialization.XmlAttributeAttribute ("expressionLanguage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExpressionLanguage {
            get {
                return this._expressionLanguage;
            }
            set {
                this._expressionLanguage = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private string _typeLanguage = "http://www.omg.org/spec/DMN/20180521/FEEL/";

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute ("http://www.omg.org/spec/DMN/20180521/FEEL/")]
        [System.Xml.Serialization.XmlAttributeAttribute ("typeLanguage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TypeLanguage {
            get {
                return this._typeLanguage;
            }
            set {
                this._typeLanguage = value;
            }
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("namespace", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Namespace { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("exporter", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Exporter { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("exporterVersion", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExporterVersion { get; set; }
    }
}