using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tInvocation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("invocation", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TInvocation : TExpression {

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TExpression Expression { get; set; }

        [XmlElement ("binding", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TBinding> Binding { get; set; } = new Collection<TBinding> ();

        [XmlIgnore]
        public bool BindingSpecified {
            get {
                return (this.Binding.Any ());
            }
        }

    }
}