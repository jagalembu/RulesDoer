using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tKnowledgeSource", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("knowledgeSource", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TKnowledgeSource : TDRGElement {

        [XmlElement ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TAuthorityRequirement> AuthorityRequirement { get; set; } = new Collection<TAuthorityRequirement> ();

        [XmlIgnore]
        public bool AuthorityRequirementSpecified {
            get {
                return (this.AuthorityRequirement.Any ());
            }
        }

        [XmlElement ("type", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string Type { get; set; }

        [XmlElement ("owner", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TDMNElementReference Owner { get; set; }

        [XmlAttribute ("locationURI", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string LocationURI { get; set; }
    }
}