namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tBinding", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TBinding {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("parameter", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TInformationItem Parameter { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("literalExpression", typeof (TLiteralExpression), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("context", typeof (TContext), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("decisionTable", typeof (TDecisionTable), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("functionDefinition", typeof (TFunctionDefinition), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("invocation", typeof (TInvocation), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        [System.Xml.Serialization.XmlElementAttribute ("relation", typeof (TRelation), Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TExpression Expression { get; set; }
    }
}