namespace RulesDoer.Core.Transformer.v1_2
{
      /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tDecisionService", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("decisionService", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TDecisionService : TInvocable {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _outputDecision;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("outputDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> OutputDecision {
            get {
                return this._outputDecision;
            }
            private set {
                this._outputDecision = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die OutputDecision-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the OutputDecision collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool OutputDecisionSpecified {
            get {
                return (this.OutputDecision.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDecisionService" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDecisionService" /> class.</para>
        /// </summary>
        public TDecisionService () {
            this._outputDecision = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._encapsulatedDecision = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._inputDecision = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
            this._inputData = new System.Collections.ObjectModel.Collection<TDMNElementReference> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _encapsulatedDecision;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("encapsulatedDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> EncapsulatedDecision {
            get {
                return this._encapsulatedDecision;
            }
            private set {
                this._encapsulatedDecision = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die EncapsulatedDecision-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the EncapsulatedDecision collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool EncapsulatedDecisionSpecified {
            get {
                return (this.EncapsulatedDecision.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _inputDecision;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("inputDecision", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> InputDecision {
            get {
                return this._inputDecision;
            }
            private set {
                this._inputDecision = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die InputDecision-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the InputDecision collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InputDecisionSpecified {
            get {
                return (this.InputDecision.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDMNElementReference> _inputData;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("inputData", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDMNElementReference> InputData {
            get {
                return this._inputData;
            }
            private set {
                this._inputData = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die InputData-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the InputData collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InputDataSpecified {
            get {
                return (this.InputData.Count != 0);
            }
        }
    }
}