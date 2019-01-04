using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tRelation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("relation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TRelation : TExpression {

        [XmlElement ("column", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TInformationItem> Column { get; set; } = new Collection<TInformationItem> ();

        [XmlIgnore]
        public bool ColumnSpecified {
            get {
                return (this.Column.Any ());
            }
        }

        [XmlElement ("row", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TList> Row { get; set; } = new Collection<TList> ();

        [XmlIgnore]
        public bool RowSpecified {
            get {
                return (this.Row.Any ());
            }
        }
    }
}