using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("TDMNElementExtensionElements", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd", AnonymousType = true)]
    public partial class TDMNElementExtensionElements {

        [XmlIgnore]
        private System.Collections.ObjectModel.Collection<System.Xml.XmlElement> _any;

        [XmlAnyElement]
        public Collection<XmlElement> Any { get; set; } = new Collection<XmlElement> ();

        [XmlIgnore]
        public bool AnySpecified {
            get {
                return (this.Any.Any ());
            }
        }

    }
}