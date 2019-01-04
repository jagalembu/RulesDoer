using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tItemDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("itemDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TItemDefinition : TNamedElement {

        [XmlElement ("typeRef", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "QName")]
        public System.Xml.XmlQualifiedName TypeRef { get; set; }

        [XmlElement ("allowedValues", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TUnaryTests AllowedValues { get; set; }

        [XmlElement ("itemComponent", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TItemDefinition> ItemComponent { get; set; } = new Collection<TItemDefinition> ();

        [XmlIgnore]
        public bool ItemComponentSpecified {
            get {
                return (this.ItemComponent.Any ());
            }
        }

        [XmlAttribute ("typeLanguage", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string TypeLanguage { get; set; }

        [XmlAttribute ("isCollection", Form = XmlSchemaForm.Unqualified, DataType = "boolean")]
        public bool IsCollection { get; set; } = false;
    }
}