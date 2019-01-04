using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tList", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("list", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TList : TExpression {

        [XmlElement ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TExpression> Expression { get; set; } = new Collection<TExpression> ();

        [XmlIgnore]
        public bool ExpressionSpecified {
            get {
                return (this.Expression.Any ());
            }
        }

    }
}