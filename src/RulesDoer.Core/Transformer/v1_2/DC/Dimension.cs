namespace RulesDoer.Core.Transformer.v1_2.DC {
    /// <summary>
    /// <para>Dimension specifies two lengths (width and height) along the x and y axes in some x-y coordinate system.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("Dimension specifies two lengths (width and height) along the x and y axes in some" +
        " x-y coordinate system.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Dimension", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("Dimension", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    public partial class Dimension {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("width", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Width { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("height", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Height { get; set; }
    }
}