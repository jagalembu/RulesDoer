using System;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tInputData", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("inputData", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TInputData : TDRGElement {

        [XmlElement ("variable", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public TInformationItem Variable { get; set; }
    }
}