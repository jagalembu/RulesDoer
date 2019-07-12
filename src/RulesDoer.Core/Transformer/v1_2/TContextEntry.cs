namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tContextEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("contextEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TContextEntry : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("variable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TInformationItem Variable { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TExpression Expression { get; set; }
    }
}