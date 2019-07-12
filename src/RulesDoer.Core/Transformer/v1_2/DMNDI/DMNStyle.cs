using RulesDoer.Core.Transformer.v1_2.DC;
using RulesDoer.Core.Transformer.v1_2.DI;

namespace RulesDoer.Core.Transformer.v1_2.DMNDI {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("DMNStyle", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("DMNStyle", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    public partial class DMNStyle : Style {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("FillColor", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public Color FillColor { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("StrokeColor", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public Color StrokeColor { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("FontColor", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public Color FontColor { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontFamily", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string FontFamily { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontSize", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public double FontSize { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FontSize-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FontSize property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FontSizeSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontItalic", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool FontItalic { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FontItalic-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FontItalic property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FontItalicSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontBold", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool FontBold { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FontBold-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FontBold property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FontBoldSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontUnderline", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool FontUnderline { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FontUnderline-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FontUnderline property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FontUnderlineSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("fontStrikeThrough", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public bool FontStrikeThrough { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die FontStrikeThrough-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the FontStrikeThrough property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool FontStrikeThroughSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("labelHorizontalAlignement", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AlignmentKind LabelHorizontalAlignement { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die LabelHorizontalAlignement-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the LabelHorizontalAlignement property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool LabelHorizontalAlignementSpecified { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("labelVerticalAlignment", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public AlignmentKind LabelVerticalAlignment { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die LabelVerticalAlignment-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the LabelVerticalAlignment property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool LabelVerticalAlignmentSpecified { get; set; }
    }
}