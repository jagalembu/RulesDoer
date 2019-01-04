using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tArtifact", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("artifact", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlInclude (typeof (TAssociation))]
    [XmlInclude (typeof (TTextAnnotation))]
    public partial class TArtifact : TDMNElement { }
}