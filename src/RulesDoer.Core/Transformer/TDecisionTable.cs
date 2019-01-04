using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDecisionTable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("decisionTable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDecisionTable : TExpression {

        [XmlElement ("input", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TInputClause> Input { get; set; } = new Collection<TInputClause> ();

        [XmlIgnore]
        public bool InputSpecified {
            get {
                return (this.Input.Any ());
            }
        }

        [XmlElement ("output", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TOutputClause> Output { get; set; } = new Collection<TOutputClause> ();

        [XmlElement ("rule", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDecisionRule> Rule { get; set; } = new Collection<TDecisionRule> ();

        [XmlIgnore]
        public bool RuleSpecified {
            get {
                return (this.Rule.Any ());
            }
        }

        [XmlAttribute ("hitPolicy", Form = XmlSchemaForm.Unqualified)]
        public THitPolicy HitPolicy { get; set; } = THitPolicy.UNIQUE;

        [XmlAttribute ("aggregation", Form = XmlSchemaForm.Unqualified)]
        public TBuiltinAggregator Aggregation { get; set; }

        [XmlIgnore]
        public bool AggregationSpecified { get; set; }

        [XmlAttribute ("preferredOrientation", Form = XmlSchemaForm.Unqualified)]
        public TDecisionTableOrientation PreferredOrientation { get; set; } = TDecisionTableOrientation.Rule_As_Row;

        [XmlAttribute ("outputLabel", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string OutputLabel { get; set; }
    }
}