namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tDecisionRule", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TDecisionRule : TDMNElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TUnaryTests> _inputEntry;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("inputEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TUnaryTests> InputEntry {
            get {
                return this._inputEntry;
            }
            private set {
                this._inputEntry = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die InputEntry-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the InputEntry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InputEntrySpecified {
            get {
                return (this.InputEntry.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDecisionRule" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDecisionRule" /> class.</para>
        /// </summary>
        public TDecisionRule () {
            this._inputEntry = new System.Collections.ObjectModel.Collection<TUnaryTests> ();
            this._outputEntry = new System.Collections.ObjectModel.Collection<TLiteralExpression> ();
            this._annotationEntry = new System.Collections.ObjectModel.Collection<TRuleAnnotation> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TLiteralExpression> _outputEntry;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("outputEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TLiteralExpression> OutputEntry {
            get {
                return this._outputEntry;
            }
            private set {
                this._outputEntry = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TRuleAnnotation> _annotationEntry;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("annotationEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TRuleAnnotation> AnnotationEntry {
            get {
                return this._annotationEntry;
            }
            private set {
                this._annotationEntry = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die AnnotationEntry-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the AnnotationEntry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool AnnotationEntrySpecified {
            get {
                return (this.AnnotationEntry.Count != 0);
            }
        }
    }
}