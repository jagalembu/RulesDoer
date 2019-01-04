using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tImport", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("import", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TImportedValues))]
    public partial class TImport {

        [XmlAttribute ("namespace", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string Namespace { get; set; }

        [XmlAttribute ("locationURI", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string LocationURI { get; set; }

        [XmlAttribute ("importType", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string ImportType { get; set; }
    }
}