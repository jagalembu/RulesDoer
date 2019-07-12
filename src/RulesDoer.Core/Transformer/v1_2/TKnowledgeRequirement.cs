namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tKnowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("knowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TKnowledgeRequirement : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("requiredKnowledge", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference RequiredKnowledge { get; set; }
    }
}