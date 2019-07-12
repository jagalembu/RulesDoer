namespace RulesDoer.Core.Transformer.v1_2.DI
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("DiagramElementExtension", Namespace="http://www.omg.org/spec/DMN/20180521/DI/", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DiagramElementExtension
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlElement> Any
        {
            get
            {
                return this._any;
            }
            private set
            {
                this._any = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Any-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Any collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AnySpecified
        {
            get
            {
                return (this.Any.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="DiagramElementExtension" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiagramElementExtension" /> class.</para>
        /// </summary>
        public DiagramElementExtension()
        {
            this._any = new System.Collections.ObjectModel.Collection<System.Xml.XmlElement>();
        }
    }
}