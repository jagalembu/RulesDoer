using RulesDoer.Core.Transformer.v1_2.DC;
using RulesDoer.Core.Transformer.v1_2.DI;

namespace RulesDoer.Core.Transformer.v1_2.DMNDI {
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute ("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute ()]
    [System.Xml.Serialization.XmlTypeAttribute ("DMNDiagram", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute ()]
    [System.ComponentModel.DesignerCategoryAttribute ("code")]
    [System.Xml.Serialization.XmlRootAttribute ("DMNDiagram", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
    public partial class DMNDiagram : Diagram {

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("Size", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public Dimension Size { get; set; }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        private System.Collections.ObjectModel.Collection<DiagramElement> _dMNDiagramElement;

        /// <summary>
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute ("DMNShape", Type = typeof (DMNShape), Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        [System.Xml.Serialization.XmlElementAttribute ("DMNEdge", Type = typeof (DMNEdge), Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        [System.Xml.Serialization.XmlElementAttribute ("DMNDiagramElement", Namespace = "http://www.omg.org/spec/DMN/20180521/DMNDI/")]
        public System.Collections.ObjectModel.Collection<DiagramElement> DMNDiagramElement {
            get {
                return this._dMNDiagramElement;
            }
            private set {
                this._dMNDiagramElement = value;
            }
        }

        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die DMNDiagramElement-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the DMNDiagramElement collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public bool DMNDiagramElementSpecified {
            get {
                return (this.DMNDiagramElement.Count != 0);
            }
        }

        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="DMNDiagram" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="DMNDiagram" /> class.</para>
        /// </summary>
        public DMNDiagram () {
            this._dMNDiagramElement = new System.Collections.ObjectModel.Collection<DiagramElement> ();
        }
    }
}