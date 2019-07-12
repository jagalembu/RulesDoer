namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tList", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("list", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TList : TExpression {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TExpression> _expression;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TExpression> Expression {
            get {
                return this._expression;
            }
            private set {
                this._expression = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Expression-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Expression collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ExpressionSpecified {
            get {
                return (this.Expression.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TList" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TList" /> class.</para>
        /// </summary>
        public TList () {
            this._expression = new System.Collections.ObjectModel.Collection<TExpression> ();
        }
    }
}