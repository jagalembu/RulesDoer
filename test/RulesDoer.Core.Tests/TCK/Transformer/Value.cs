using System.Xml;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Tests.TCK.Transformer {
    [System.Xml.Serialization.XmlTypeAttribute ("valueDef", Namespace = "http://www.omg.org/spec/DMN/20160719/testcase")]
    [System.Xml.Serialization.XmlInclude (typeof (TypeString))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeDecimal))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeBoolean))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeDate))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeDateTime))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeTime))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeDuration))]
    [System.Xml.Serialization.XmlInclude (typeof (TypeDouble))]
    [System.SerializableAttribute ()]
    public partial class Value {

        private string _val;

        [System.Xml.Serialization.XmlText (typeof(string))]
        public virtual string Val {
            get { return _val; }
            set {
                _val = value;
            }
        }

        [System.Xml.Serialization.XmlIgnoreAttribute ()]
        public virtual string Type { get; set; }

    }
}