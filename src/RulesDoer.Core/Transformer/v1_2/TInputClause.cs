namespace RulesDoer.Core.Transformer.v1_2
{
      /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tInputClause", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TInputClause : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("inputExpression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TLiteralExpression InputExpression { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("inputValues", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TUnaryTests InputValues { get; set; }
    }
}