using RulesDoer.Core.Transformer.v1_2.DC;
using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2.DI {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("Shape", Namespace = "http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNLabel))]
    [System.Xml.Serialization.XmlIncludeAttribute (typeof (DMNShape))]
    public partial class Shape : DiagramElement {

        /// <summary>
        /// <para>the optional bounds of the shape relative to the origin of its nesting plane.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute ("the optional bounds of the shape relative to the origin of its nesting plane.")]
        [System.Xml.Serialization.XmlElementAttribute ("Bounds", Namespace = "http://www.omg.org/spec/DMN/20180521/DC/")]
        public Bounds Bounds { get; set; }
    }
}