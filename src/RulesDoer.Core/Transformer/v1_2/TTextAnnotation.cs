namespace RulesDoer.Core.Transformer.v1_2
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tTextAnnotation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("textAnnotation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TTextAnnotation : TArtifact {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("text", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string Text { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private string _textFormat = "text/plain";

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute ("text/plain")]
        [System.Xml.Serialization.XmlAttributeAttribute ("textFormat", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TextFormat {
            get {
                return this._textFormat;
            }
            set {
                this._textFormat = value;
            }
        }
    }
}