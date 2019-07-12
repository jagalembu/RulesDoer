namespace RulesDoer.Core.Transformer.v1_2 {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("tDecisionTable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("decisionTable", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
    public partial class TDecisionTable : TExpression {

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TInputClause> _input;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("input", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TInputClause> Input {
            get {
                return this._input;
            }
            private set {
                this._input = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Input-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Input collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool InputSpecified {
            get {
                return (this.Input.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="TDecisionTable" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="TDecisionTable" /> class.</para>
        /// </summary>
        public TDecisionTable () {
            this._input = new System.Collections.ObjectModel.Collection<TInputClause> ();
            this._output = new System.Collections.ObjectModel.Collection<TOutputClause> ();
            this._annotation = new System.Collections.ObjectModel.Collection<TRuleAnnotationClause> ();
            this._rule = new System.Collections.ObjectModel.Collection<TDecisionRule> ();
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TOutputClause> _output;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("output", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TOutputClause> Output {
            get {
                return this._output;
            }
            private set {
                this._output = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TRuleAnnotationClause> _annotation;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("annotation", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TRuleAnnotationClause> Annotation {
            get {
                return this._annotation;
            }
            private set {
                this._annotation = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Annotation-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Annotation collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool AnnotationSpecified {
            get {
                return (this.Annotation.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<TDecisionRule> _rule;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("rule", Namespace = "http://www.omg.org/spec/DMN/20180521/MODEL/")]
        public System.Collections.ObjectModel.Collection<TDecisionRule> Rule {
            get {
                return this._rule;
            }
            private set {
                this._rule = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Rule-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Rule collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool RuleSpecified {
            get {
                return (this.Rule.Count != 0);
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private THitPolicy _hitPolicy = THitPolicy.UNIQUE;

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute (THitPolicy.UNIQUE)]
        [System.Xml.Serialization.XmlAttributeAttribute ("hitPolicy", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public THitPolicy HitPolicy {
            get {
                return this._hitPolicy;
            }
            set {
                this._hitPolicy = value;
            }
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("aggregation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TBuiltinAggregator Aggregation { get; set; }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Aggregation-Eigenschaft spezifiziert ist, oder legt diesen fest.</para>
        /// <para xml:lang="en">Gets or sets a value indicating whether the Aggregation property is specified.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool AggregationSpecified { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private TDecisionTableOrientation _preferredOrientation = TDecisionTableOrientation.Rule_As_Row;

        /// <summary>
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute (TDecisionTableOrientation.Rule_As_Row)]
        [System.Xml.Serialization.XmlAttributeAttribute ("preferredOrientation", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public TDecisionTableOrientation PreferredOrientation {
            get {
                return this._preferredOrientation;
            }
            set {
                this._preferredOrientation = value;
            }
        }

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute ("outputLabel", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string OutputLabel { get; set; }
    }
}