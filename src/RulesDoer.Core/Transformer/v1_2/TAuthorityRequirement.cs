namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tAuthorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TAuthorityRequirement : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("requiredDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference RequiredDecision { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("requiredInput", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference RequiredInput { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("requiredAuthority", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference RequiredAuthority { get; set; }
    }
}