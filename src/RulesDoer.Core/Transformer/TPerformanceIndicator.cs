using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tPerformanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("performanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TPerformanceIndicator : TBusinessContextElement {

        [XmlElement ("impactingDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> ImpactingDecision { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool ImpactingDecisionSpecified {
            get {
                return (this.ImpactingDecision.Any ());
            }
        }

    }
}