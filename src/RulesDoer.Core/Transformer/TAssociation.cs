using System;
using System.ComponentModel;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tAssociation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("association", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TAssociation : TArtifact {

        [XmlElement ("sourceRef", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference SourceRef { get; set; }

        [XmlElement ("targetRef", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference TargetRef { get; set; }

        [XmlAttribute ("associationDirection", Form = XmlSchemaForm.Unqualified)]
        public TAssociationDirection AssociationDirection { get; set; } = TAssociationDirection.None;
    }
}