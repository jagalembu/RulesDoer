using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tHitPolicy", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public enum THitPolicy {

        UNIQUE,

        FIRST,

        PRIORITY,

        ANY,

        COLLECT,

        [XmlEnum ("RULE ORDER")]
        RULE_ORDER,

        [XmlEnum ("OUTPUT ORDER")]
        OUTPUT_ORDER,
    }

}