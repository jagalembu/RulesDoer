using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tInformationItem", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("informationItem", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TInformationItem : TNamedElement {

        [XmlAttribute ("typeRef", Form = XmlSchemaForm.Unqualified, DataType = "QName")]
        public System.Xml.XmlQualifiedName TypeRef { get; set; }
    }
}