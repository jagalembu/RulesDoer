using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDecisionRule", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDecisionRule : TDMNElement {

        [XmlElement ("inputEntry", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TUnaryTests> InputEntry { get; set; } = new Collection<TUnaryTests> ();

        [XmlIgnore]
        public bool InputEntrySpecified {
            get {
                return (this.InputEntry.Any ());
            }
        }

        [XmlElement ("outputEntry", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TLiteralExpression> OutputEntry { get; set; } = new Collection<TLiteralExpression> ();
    }
}