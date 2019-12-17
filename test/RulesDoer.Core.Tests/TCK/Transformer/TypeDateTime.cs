namespace RulesDoer.Core.Tests.TCK.Transformer {
    [System.Xml.Serialization.XmlTypeAttribute ("dateTime", Namespace = "http://www.w3.org/2001/XMLSchema")]
    public class TypeDateTime : Value {
        [System.Xml.Serialization.XmlAttribute ("type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public override string Type { get; set; }
    }
}