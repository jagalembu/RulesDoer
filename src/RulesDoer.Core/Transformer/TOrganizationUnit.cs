using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tOrganizationUnit", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("organizationUnit", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TOrganizationUnit : TBusinessContextElement {

        [XmlElement ("decisionMade", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> DecisionMade { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool DecisionMadeSpecified {
            get {
                return (this.DecisionMade.Any ());
            }
        }

        [XmlElement ("decisionOwned", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> DecisionOwned { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool DecisionOwnedSpecified {
            get {
                return (this.DecisionOwned.Any ());
            }
        }
    }
}