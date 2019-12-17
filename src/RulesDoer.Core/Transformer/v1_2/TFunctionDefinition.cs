using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tFunctionDefinition", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("functionDefinition", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TFunctionDefinition : TExpression {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TInformationItem> _formalParameter;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("formalParameter", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TInformationItem> FormalParameter {
            get {
                return this._formalParameter;
            }
            private set {
                this._formalParameter = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FormalParameter-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the FormalParameter collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FormalParameterSpecified {
            get {
                return (this.FormalParameter.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TFunctionDefinition" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TFunctionDefinition" /> class.</para>
        /// </summary>
        public TFunctionDefinition () {
            this._formalParameter = new System.Collections.ObjectModel.Collection<TInformationItem> ();
        }

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
        private TFunctionKind _kind = TFunctionKind.FEEL;

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute (TFunctionKind.FEEL)]
        [System.Xml.Serialization.XmlAttributeAttribute ("kind", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TFunctionKind Kind {
            get {
                return this._kind;
            }
            set {
                this._kind = value;
            }
        }
    }
}