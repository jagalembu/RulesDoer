namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("decision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TDecision : TDRGElement {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("question", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string Question { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("allowedAnswers", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public string AllowedAnswers { get; set; }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("variable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TInformationItem Variable { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TInformationRequirement> _informationRequirement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("informationRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TInformationRequirement> InformationRequirement {
            get {
                return this._informationRequirement;
            }
            private set {
                this._informationRequirement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die InformationRequirement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the InformationRequirement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InformationRequirementSpecified {
            get {
                return (this.InformationRequirement.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDecision" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDecision" /> class.</para>
        /// </summary>
        public TDecision () {
            this._informationRequirement = new System.Collections.ObjectModel.Collection<TInformationRequirement> ();
            this._knowledgeRequirement = new System.Collections.ObjectModel.Collection<TKnowledgeRequirement> ();
            this._authorityRequirement = new System.Collections.ObjectModel.Collection<TAuthorityRequirement> ();
            this._supportedObjective = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._impactedPerformanceIndicator = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._decisionMaker = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._decisionOwner = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._usingProcess = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._usingTask = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TKnowledgeRequirement> _knowledgeRequirement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("knowledgeRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TKnowledgeRequirement> KnowledgeRequirement {
            get {
                return this._knowledgeRequirement;
            }
            private set {
                this._knowledgeRequirement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die KnowledgeRequirement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the KnowledgeRequirement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool KnowledgeRequirementSpecified {
            get {
                return (this.KnowledgeRequirement.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TAuthorityRequirement> _authorityRequirement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("authorityRequirement", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TAuthorityRequirement> AuthorityRequirement {
            get {
                return this._authorityRequirement;
            }
            private set {
                this._authorityRequirement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die AuthorityRequirement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the AuthorityRequirement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool AuthorityRequirementSpecified {
            get {
                return (this.AuthorityRequirement.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _supportedObjective;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("supportedObjective", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> SupportedObjective {
            get {
                return this._supportedObjective;
            }
            private set {
                this._supportedObjective = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die SupportedObjective-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the SupportedObjective collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool SupportedObjectiveSpecified {
            get {
                return (this.SupportedObjective.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _impactedPerformanceIndicator;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("impactedPerformanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> ImpactedPerformanceIndicator {
            get {
                return this._impactedPerformanceIndicator;
            }
            private set {
                this._impactedPerformanceIndicator = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ImpactedPerformanceIndicator-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ImpactedPerformanceIndicator collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ImpactedPerformanceIndicatorSpecified {
            get {
                return (this.ImpactedPerformanceIndicator.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _decisionMaker;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("decisionMaker", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> DecisionMaker {
            get {
                return this._decisionMaker;
            }
            private set {
                this._decisionMaker = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DecisionMaker-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DecisionMaker collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DecisionMakerSpecified {
            get {
                return (this.DecisionMaker.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _decisionOwner;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("decisionOwner", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> DecisionOwner {
            get {
                return this._decisionOwner;
            }
            private set {
                this._decisionOwner = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DecisionOwner-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DecisionOwner collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DecisionOwnerSpecified {
            get {
                return (this.DecisionOwner.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _usingProcess;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("usingProcess", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> UsingProcess {
            get {
                return this._usingProcess;
            }
            private set {
                this._usingProcess = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die UsingProcess-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the UsingProcess collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool UsingProcessSpecified {
            get {
                return (this.UsingProcess.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _usingTask;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("usingTask", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> UsingTask {
            get {
                return this._usingTask;
            }
            private set {
                this._usingTask = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die UsingTask-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the UsingTask collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool UsingTaskSpecified {
            get {
                return (this.UsingTask.Count != 0);
            }
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("expression", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public TExpression Expression { get; set; }
    }
}