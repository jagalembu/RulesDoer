namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tInvocable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("invocable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TBusinessKnowledgeModel))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (TDecisionService))]
    public partial class TInvocable : TDRGElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("variable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TInformationItem Variable { get; set; }
    }
}