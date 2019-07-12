namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tHitPolicy", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public enum THitPolicy {

        /// <summary>
        /// </summary>
        UNIQUE,

        /// <summary>
        /// </summary>
        FIRST,

        /// <summary>
        /// </summary>
        PRIORITY,

        /// <summary>
        /// </summary>
        ANY,

        /// <summary>
        /// </summary>
        COLLECT,

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute ("RULE ORDER")]
        RULE_ORDER,

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlEnumAttribute ("OUTPUT ORDER")]
        OUTPUT_ORDER,
    }

}