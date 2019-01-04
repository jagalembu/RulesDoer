using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDMNElementReference", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDMNElementReference {

        [XmlAttribute ("href", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string Href { get; set; }
    }
}