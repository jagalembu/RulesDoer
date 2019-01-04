using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDecision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("decision", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDecision : TDRGElement {

        [XmlElement ("question", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string Question { get; set; }

        [XmlElement ("allowedAnswers", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", DataType = "string")]
        public string AllowedAnswers { get; set; }

        [XmlElement ("variable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TInformationItem Variable { get; set; }

        [XmlElement ("informationRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TInformationRequirement> InformationRequirement { get; set; } = new Collection<TInformationRequirement> ();

        [XmlIgnore]
        public bool InformationRequirementSpecified {
            get {
                return (this.InformationRequirement.Any ());
            }
        }

        [XmlElement ("knowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TKnowledgeRequirement> KnowledgeRequirement { get; set; } = new Collection<TKnowledgeRequirement> ();

        [XmlIgnore]
        public bool KnowledgeRequirementSpecified {
            get {
                return (this.KnowledgeRequirement.Any ());
            }
        }

        [XmlElement ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TAuthorityRequirement> AuthorityRequirement { get; set; } = new Collection<TAuthorityRequirement> ();

        [XmlIgnore]
        public bool AuthorityRequirementSpecified {
            get {
                return (this.AuthorityRequirement.Any ());
            }
        }

        [XmlElement ("supportedObjective", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> SupportedObjective { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool SupportedObjectiveSpecified {
            get {
                return (this.SupportedObjective.Any ());
            }
        }

        [XmlElement ("impactedPerformanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> ImpactedPerformanceIndicator { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool ImpactedPerformanceIndicatorSpecified {
            get {
                return (this.ImpactedPerformanceIndicator.Any ());
            }
        }

        [XmlElement ("decisionMaker", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> DecisionMaker { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool DecisionMakerSpecified {
            get {
                return (this.DecisionMaker.Any ());
            }
        }

        [XmlElement ("decisionOwner", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> DecisionOwner { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool DecisionOwnerSpecified {
            get {
                return (this.DecisionOwner.Any ());
            }
        }

        [XmlElement ("usingProcess", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> UsingProcess { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool UsingProcessSpecified {
            get {
                return (this.UsingProcess.Any ());
            }
        }

        [XmlElement ("usingTask", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> UsingTask { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool UsingTaskSpecified {
            get {
                return (this.UsingTask.Any ());
            }
        }

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TExpression Expression { get; set; }
    }
}