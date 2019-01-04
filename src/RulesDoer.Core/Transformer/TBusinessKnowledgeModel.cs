using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tBusinessKnowledgeModel", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("businessKnowledgeModel", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TBusinessKnowledgeModel : TDRGElement {

        [XmlElement ("encapsulatedLogic", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TFunctionDefinition EncapsulatedLogic { get; set; }

        [XmlElement ("variable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TInformationItem Variable { get; set; }

        [XmlIgnore]
        private System.Collections.ObjectModel.Collection<TKnowledgeRequirement> _knowledgeRequirement;

        [XmlElement ("knowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public System.Collections.ObjectModel.Collection<TKnowledgeRequirement> KnowledgeRequirement {
            get {
                return this._knowledgeRequirement;
            }
            private set {
                this._knowledgeRequirement = value;
            }
        }

        [XmlIgnore]
        public bool KnowledgeRequirementSpecified {
            get {
                return (this.KnowledgeRequirement.Count != 0);
            }
        }

        public TBusinessKnowledgeModel () {
            this._knowledgeRequirement = new System.Collections.ObjectModel.Collection<TKnowledgeRequirement> ();
            this._authorityRequirement = new System.Collections.ObjectModel.Collection<TAuthorityRequirement> ();
        }

        [XmlIgnore]
        private System.Collections.ObjectModel.Collection<TAuthorityRequirement> _authorityRequirement;

        [XmlElement ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public System.Collections.ObjectModel.Collection<TAuthorityRequirement> AuthorityRequirement {
            get {
                return this._authorityRequirement;
            }
            private set {
                this._authorityRequirement = value;
            }
        }

        [XmlIgnore]
        public bool AuthorityRequirementSpecified {
            get {
                return (this.AuthorityRequirement.Count != 0);
            }
        }
    }
}