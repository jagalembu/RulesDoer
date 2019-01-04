using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDecisionService", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("decisionService", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDecisionService : TNamedElement {

        [XmlElement ("outputDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> OutputDecision { get; set; } = new Collection<TDMNElementReference> ();

        [XmlElement ("encapsulatedDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> EncapsulatedDecision { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool EncapsulatedDecisionSpecified {
            get {
                return (this.EncapsulatedDecision.Any ());
            }
        }

        [XmlElement ("inputDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> InputDecision { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool InputDecisionSpecified {
            get {
                return (this.InputDecision.Any ());
            }
        }

        [XmlElement ("inputData", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> InputData { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool InputDataSpecified {
            get {
                return (this.InputData.Any ());
            }
        }
    }
}