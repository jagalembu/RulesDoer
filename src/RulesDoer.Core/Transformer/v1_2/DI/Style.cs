using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2.DI
{
    /// <summary>
    /// <para>Style contains formatting properties that affect the appearance or style of diagram elements, including diagram themselves.</para>
    /// <para>This element should never be instantiated directly, but rather concrete implementation should. It is placed there only to be referred in the sequence</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Style contains formatting properties that affect the appearance or style of diagr" +
        "am elements, including diagram themselves.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Style", Namespace="http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("Style", Namespace="http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMNStyle))]
    public partial class Style
    {
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute("extension", Namespace="http://www.omg.org/spec/DMN/20180521/DI/")]
        public StyleExtension Extension { get; set; }
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute("id", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> _anyAttribute;
        
        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> AnyAttribute
        {
            get
            {
                return this._anyAttribute;
            }
            private set
            {
                this._anyAttribute = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="Style" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="Style" /> class.</para>
        /// </summary>
        public Style()
        {
            this._anyAttribute = new System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute>();
        }
    }
}