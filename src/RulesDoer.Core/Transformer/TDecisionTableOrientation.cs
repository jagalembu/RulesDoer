using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDecisionTableOrientation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public enum TDecisionTableOrientation {

        [XmlEnum ("Rule-as-Row")]
        Rule_As_Row,

        [XmlEnum ("Rule-as-Column")]
        Rule_As_Column,

        CrossTable,
    }

}