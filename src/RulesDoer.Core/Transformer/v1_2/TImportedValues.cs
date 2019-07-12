namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tImportedValues", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TImportedValues : TImport {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("importedElement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string ImportedElement { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("expressionLanguage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExpressionLanguage { get; set; }
    }
}