using System;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tExpression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("expression", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TContext))]
    [XmlInclude (typeof (TDecisionTable))]
    [XmlInclude (typeof (TFunctionDefinition))]
    [XmlInclude (typeof (TInvocation))]
    [XmlInclude (typeof (TList))]
    [XmlInclude (typeof (TLiteralExpression))]
    [XmlInclude (typeof (TRelation))]
    public partial class TExpression : TDMNElement {

        [XmlAttribute ("typeRef", Form = XmlSchemaForm.Unqualified, DataType = "QName")]
        public System.Xml.XmlQualifiedName TypeRef { get; set; }
    }
}