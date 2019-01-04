using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tImportedValues", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TImportedValues : TImport {

        [XmlElement ("importedElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string ImportedElement { get; set; }

        [XmlAttribute ("expressionLanguage", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string ExpressionLanguage { get; set; }
    }
}