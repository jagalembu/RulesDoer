namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("tItemDefinition", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("itemDefinition", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TItemDefinition : TNamedElement
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("typeRef", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string TypeRef { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("allowedValues", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TUnaryTests AllowedValues { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<TItemDefinition> _itemComponent;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("itemComponent", Namespace="http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TItemDefinition> ItemComponent
        {
            get
            {
                return this._itemComponent;
            }
            private set
            {
                this._itemComponent = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ItemComponent-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ItemComponent collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemComponentSpecified
        {
            get
            {
                return (this.ItemComponent.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TItemDefinition" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TItemDefinition" /> class.</para>
        /// </summary>
        public TItemDefinition()
        {
            this._itemComponent = new System.Collections.ObjectModel.Collection<TItemDefinition>();
        }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("typeLanguage", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TypeLanguage { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private bool _isCollection = false;
        
        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.Xml.Serialization.XmlAttributeAttribute("isCollection", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool IsCollection
        {
            get
            {
                return this._isCollection;
            }
            set
            {
                this._isCollection = value;
            }
        }
    }
}