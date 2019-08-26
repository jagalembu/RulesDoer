using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tLiteralExpression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("literalExpression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TLiteralExpression : TExpression {

        private string _text;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("text", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string Text { get => _text; set => _text = StringUtils.Unescape (value); }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("importedValues", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TImportedValues ImportedValues { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("expressionLanguage", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ExpressionLanguage { get; set; }
    }
}