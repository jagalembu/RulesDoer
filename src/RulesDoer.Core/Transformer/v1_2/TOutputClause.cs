using System.Collections.Generic;
using System.Xml.Serialization;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tOutputClause", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    public partial class TOutputClause : TDMNElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("outputValues", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TUnaryTests OutputValues { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("defaultOutputEntry", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TLiteralExpression DefaultOutputEntry { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("name", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("typeRef", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string TypeRef { get; set; }

        [XmlIgnore]
        public Dictionary<Variable, int> PriorityList { get; set; } = new Dictionary<Variable, int> ();
    }
}