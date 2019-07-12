namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tExpression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TContext))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TDecisionTable))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TFunctionDefinition))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TInvocation))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TList))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TLiteralExpression))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TRelation))]
    public partial class TExpression : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("typeRef", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TypeRef { get; set; }
    }
}