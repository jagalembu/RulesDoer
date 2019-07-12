namespace RulesDoer.Core.Transformer.v1_2.DC {
    /// <summary>
    /// <para>Bounds specifies a rectangular area in some x-y coordinate system that is defined by a location (x and y) and a size (width and height).</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("Bounds specifies a rectangular area in some x-y coordinate system that is defined" +
        " by a location (x and y) and a size (width and height).")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Bounds", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("Bounds", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    public partial class Bounds {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("x", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double X { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("y", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Y { get; set; }

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