namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tRelation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("relation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TRelation : TExpression {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TInformationItem> _column;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("column", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TInformationItem> Column {
            get {
                return this._column;
            }
            private set {
                this._column = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Column-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Column collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ColumnSpecified {
            get {
                return (this.Column.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TRelation" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TRelation" /> class.</para>
        /// </summary>
        public TRelation () {
            this._column = new System.Collections.ObjectModel.Collection<TInformationItem> ();
            this._row = new System.Collections.ObjectModel.Collection<TList> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TList> _row;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("row", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TList> Row {
            get {
                return this._row;
            }
            private set {
                this._row = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Row-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Row collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool RowSpecified {
            get {
                return (this.Row.Count != 0);
            }
        }
    }
}