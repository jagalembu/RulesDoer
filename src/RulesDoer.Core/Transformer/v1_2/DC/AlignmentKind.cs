namespace RulesDoer.Core.Transformer.v1_2.DC {
    /// <summary>
    /// <para>AlignmentKind enumerates the possible options for alignment for layout purposes.</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute ("AlignmentKind enumerates the possible options for alignment for layout purposes.")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("AlignmentKind", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
    public enum AlignmentKind {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute ("start")]
        Start,

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute ("end")]
        End,

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute ("center")]
        Center,
    }
}