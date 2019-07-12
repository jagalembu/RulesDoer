namespace RulesDoer.Core.Transformer.v1_2.DC {
    /// <summary>
    /// <para>A Point specifies an location in some x-y coordinate system.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("A Point specifies an location in some x-y coordinate system.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Point", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("Point", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    public partial class Point {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("x", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double X { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("y", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double Y { get; set; }
    }
}