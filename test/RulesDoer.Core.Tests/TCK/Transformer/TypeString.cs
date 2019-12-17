namespace RulesDoer.Core.Tests.TCK.Transformer {
    [System.Xml.Serialization.XmlTypeAttribute ("string", Namespace = "http://www.w3.org/2001/XMLSchema")]
    [System.SerializableAttribute ()]
    public partial class TypeString : Value {

        [System.Xml.Serialization.XmlAttribute ("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }
    }
}