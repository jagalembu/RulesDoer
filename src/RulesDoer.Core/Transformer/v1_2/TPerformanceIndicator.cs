namespace RulesDoer.Core.Transformer.v1_2
{
     /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tPerformanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("performanceIndicator", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TPerformanceIndicator : TBusinessContextElement {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _impactingDecision;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("impactingDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> ImpactingDecision {
            get {
                return this._impactingDecision;
            }
            private set {
                this._impactingDecision = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die ImpactingDecision-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the ImpactingDecision collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool ImpactingDecisionSpecified {
            get {
                return (this.ImpactingDecision.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TPerformanceIndicator" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TPerformanceIndicator" /> class.</para>
        /// </summary>
        public TPerformanceIndicator () {
            this._impactingDecision = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
        }
    }
}