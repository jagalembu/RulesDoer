namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tAssociation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("association", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TAssociation : TArtifact {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("sourceRef", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference SourceRef { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("targetRef", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TDMNElementReference TargetRef { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private TAssociationDirection _associationDirection = TAssociationDirection.None;

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute (TAssociationDirection.None)]
        [System.Xml.Serialization.XmlAttributeAttribute ("associationDirection", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TAssociationDirection AssociationDirection {
            get {
                return this._associationDirection;
            }
            set {
                this._associationDirection = value;
            }
        }
    }
}