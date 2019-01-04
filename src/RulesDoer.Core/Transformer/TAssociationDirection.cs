using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {
    [Serializable]
    [XmlType ("tAssociationDirection", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public enum TAssociationDirection {

        None,

        One,

        Both,
    }
}