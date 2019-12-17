namespace RulesDoer.Core.Transformer.v1_2
{
      /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tInvocation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("invocation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TInvocation : TExpression {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("literalExpression", typeof (TLiteralExpression), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("context", typeof (TContext), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("decisionTable", typeof (TDecisionTable), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("functionDefinition", typeof (TFunctionDefinition), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("invocation", typeof (TInvocation), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("relation", typeof (TRelation), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TExpression Expression { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TBinding> _binding;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("binding", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TBinding> Binding {
            get {
                return this._binding;
            }
            private set {
                this._binding = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Binding-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Binding collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool BindingSpecified {
            get {
                return (this.Binding.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TInvocation" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TInvocation" /> class.</para>
        /// </summary>
        public TInvocation () {
            this._binding = new System.Collections.ObjectModel.Collection<TBinding> ();
        }
    }
}