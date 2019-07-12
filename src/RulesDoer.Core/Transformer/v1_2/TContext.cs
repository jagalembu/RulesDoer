namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tContext", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("context", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TContext : TExpression {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TContextEntry> _contextEntry;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("contextEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TContextEntry> ContextEntry {
            get {
                return this._contextEntry;
            }
            private set {
                this._contextEntry = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ContextEntry-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ContextEntry collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ContextEntrySpecified {
            get {
                return (this.ContextEntry.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TContext" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TContext" /> class.</para>
        /// </summary>
        public TContext () {
            this._contextEntry = new System.Collections.ObjectModel.Collection<TContextEntry> ();
        }
    }
}