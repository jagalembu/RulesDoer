using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tBusinessContextElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("businessContextElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TOrganizationUnit))]
    [XmlInclude (typeof (TPerformanceIndicator))]
    public partial class TBusinessContextElement : TNamedElement {

        [XmlAttribute ("URI", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string URI { get; set; }
    }
}