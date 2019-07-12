using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2.DI {
    /// <summary>
    /// <para>DiagramElement is the abstract super type of all elements in diagrams, including diagrams themselves. When contained in a diagram, diagram elements are laid out relative to the diagram's origin.</para>
    /// <para>This element should never be instantiated directly, but rather concrete implementation should. It is placed there only to be referred in the sequence</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("DiagramElement is the abstract super type of all elements in diagrams, including " +
        "diagrams themselves. When contained in a diagram, diagram elements are laid out " +
        "relative to the diagram\'s origin.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("DiagramElement", Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("DMNDiagramElement", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (Diagram))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNDecisionServiceDividerLine))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNDiagram))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNEdge))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNLabel))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNShape))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (Edge))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (Shape))]
    public partial class DiagramElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("extension", Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
        public DiagramElementExtension Extension { get; set; }

        /// <summary>
        /// <para>an optional locally-owned style for this diagram element.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("an optional locally-owned style for this diagram element.")]
        [System.Xml.Serialization.XmlElementAttribute ("DMNStyle", Type = typeof (DMNStyle), Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
        [System.Xml.Serialization.XmlElementAttribute ("Style", Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
        public Style Style { get; set; }

        /// <summary>
        /// <para>a reference to an optional shared style element for this diagram element.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("a reference to an optional shared style element for this diagram element.")]
        [System.Xml.Serialization.XmlAttributeAttribute ("sharedStyle", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string SharedStyle { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("id", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Id { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> _anyAttribute;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAnyAttributeAttribute ()]
        public System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> AnyAttribute {
            get {
                return this._anyAttribute;
            }
            private set {
                this._anyAttribute = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="DiagramElement" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DiagramElement" /> class.</para>
        /// </summary>
        public DiagramElement () {
            this._anyAttribute = new System.Collections.ObjectModel.Collection<System.Xml.XmlAttribute> ();
        }
    }
}