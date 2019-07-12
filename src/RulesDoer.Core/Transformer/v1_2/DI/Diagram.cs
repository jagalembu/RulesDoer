using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2.DI {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Diagram", Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNDiagram))]
    public partial class Diagram : DiagramElement {

        /// <summary>
        /// <para>the name of the diagram.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("the name of the diagram.")]
        [System.Xml.Serialization.XmlAttributeAttribute ("name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        /// <summary>
        /// <para>the documentation of the diagram.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("the documentation of the diagram.")]
        [System.Xml.Serialization.XmlAttributeAttribute ("documentation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Documentation { get; set; }

        /// <summary>
        /// <para>the resolution of the diagram expressed in user units per inch.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("the resolution of the diagram expressed in user units per inch.")]
        [System.Xml.Serialization.XmlAttributeAttribute ("resolution", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Resolution { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Resolution-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Resolution property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ResolutionSpecified { get; set; }
    }
}