using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tContext", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("context", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TContext : TExpression {

        [XmlElement ("contextEntry", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TContextEntry> ContextEntry { get; set; } = new Collection<TContextEntry> ();

        [XmlIgnore]
        public bool ContextEntrySpecified {
            get {
                return (this.ContextEntry.Any ());
            }
        }

    }
}