namespace RulesDoer.Core.Transformer.v1_2.DC {
    /// <summary>
    /// <para>Color is a data type that represents a color value in the RGB format.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("Color is a data type that represents a color value in the RGB format.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Color", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("Color", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    public partial class Color {

        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 255.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RangeAttribute (typeof (int), "0", "255")]
        [System.Xml.Serialization.XmlAttributeAttribute ("red", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Red { get; set; }

        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 255.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RangeAttribute (typeof (int), "0", "255")]
        [System.Xml.Serialization.XmlAttributeAttribute ("green", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Green { get; set; }

        /// <summary>
        /// <para xml:lang="en">Minimum inclusive value: 0.</para>
        /// <para xml:lang="en">Maximum inclusive value: 255.</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RangeAttribute (typeof (int), "0", "255")]
        [System.Xml.Serialization.XmlAttributeAttribute ("blue", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int Blue { get; set; }
    }
}