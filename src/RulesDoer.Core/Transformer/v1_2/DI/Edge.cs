using RulesDoer.Core.Transformer.v1_2.DC;
using RulesDoer.Core.Transformer.v1_2.DMNDI;

namespace RulesDoer.Core.Transformer.v1_2.DI
{
    /// <summary>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("Edge", Namespace="http://www.omg.org/spec/DMN/20180521/DI/")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMNDecisionServiceDividerLine))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(DMNEdge))]
    public partial class Edge : DiagramElement
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<Point> _waypoint;
        
        /// <summary>
        /// <para>an optional list of points relative to the origin of the nesting diagram that specifies the connected line segments of the edge</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("an optional list of points relative to the origin of the nesting diagram that spe" +
            "cifies the connected line segments of the edge")]
        [System.Xml.Serialization.XmlElementAttribute("waypoint", Namespace="http://www.omg.org/spec/DMN/20180521/DI/")]
        public System.Collections.ObjectModel.Collection<Point> Waypoint
        {
            get
            {
                return this._waypoint;
            }
            private set
            {
                this._waypoint = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Ruft einen Wert ab, der angibt, ob die Waypoint-Collection leer ist.</para>
        /// <para xml:lang="en">Gets a value indicating whether the Waypoint collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool WaypointSpecified
        {
            get
            {
                return (this.Waypoint.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="de">Initialisiert eine neue Instanz der <see cref="Edge" /> Klasse.</para>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="Edge" /> class.</para>
        /// </summary>
        public Edge()
        {
            this._waypoint = new System.Collections.ObjectModel.Collection<Point>();
        }
    }
}