using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tFunctionDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("functionDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TFunctionDefinition : TExpression {

        [XmlElement ("formalParameter", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TInformationItem> FormalParameter { get; set; } = new Collection<TInformationItem> ();

        [XmlIgnore]
        public bool FormalParameterSpecified {
            get {
                return (this.FormalParameter.Any ());
            }
        }

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TExpression Expression { get; set; }
    }
}