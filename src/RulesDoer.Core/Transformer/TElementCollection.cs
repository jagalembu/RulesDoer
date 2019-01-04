using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tElementCollection", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("elementCollection", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TElementCollection : TNamedElement {

        [XmlElement ("drgElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDMNElementReference> DrgElement { get; set; } = new Collection<TDMNElementReference> ();

        [XmlIgnore]
        public bool DrgElementSpecified {
            get {
                return (this.DrgElement.Any ());
            }
        }

    }
}