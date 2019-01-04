using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RulesDoer.Core.Transformer {

    [Serializable]
    [XmlType ("tDefinitions", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    [XmlRoot ("definitions", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
    public partial class TDefinitions : TNamedElement {

        [XmlElement ("import", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TImport> Import { get; set; } = new Collection<TImport> ();

        [XmlIgnore]
        public bool ImportSpecified {
            get {
                return (this.Import.Any ());
            }
        }

        [XmlElement ("itemDefinition", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TItemDefinition> ItemDefinition { get; set; } = new Collection<TItemDefinition> ();

        [XmlIgnore]
        public bool ItemDefinitionSpecified {
            get {
                return (this.ItemDefinition.Any ());
            }
        }

        [XmlElement ("drgElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TDRGElement> DrgElement { get; set; } = new Collection<TDRGElement> ();

        [XmlIgnore]
        public bool DrgElementSpecified {
            get {
                return (this.DrgElement.Any ());
            }
        }

        [XmlElement ("artifact", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TArtifact> Artifact { get; set; } = new Collection<TArtifact> ();

        [XmlIgnore]
        public bool ArtifactSpecified {
            get {
                return (this.Artifact.Any ());
            }
        }

        [XmlElement ("elementCollection", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TElementCollection> ElementCollection { get; set; } = new Collection<TElementCollection> ();

        [XmlIgnore]
        public bool ElementCollectionSpecified {
            get {
                return (this.ElementCollection.Any ());
            }
        }

        [XmlElement ("businessContextElement", Namespace = "http://www.omg.org/spec/DMN/20151101/dmn.xsd")]
        public Collection<TBusinessContextElement> BusinessContextElement { get; set; } = new Collection<TBusinessContextElement> ();

        [XmlIgnore]
        public bool BusinessContextElementSpecified {
            get {
                return (this.BusinessContextElement.Any ());
            }
        }

        [XmlAttribute ("expressionLanguage", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string ExpressionLanguage { get; set; } = "http://www.omg.org/spec/FEEL/20140401";

        [XmlAttribute ("typeLanguage", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string TypeLanguage { get; set; } = "http://www.omg.org/spec/FEEL/20140401";

        [XmlAttribute ("namespace", Form = XmlSchemaForm.Unqualified, DataType = "anyURI")]
        public string Namespace { get; set; }

        [XmlAttribute ("exporter", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string Exporter { get; set; }

        [XmlAttribute ("exporterVersion", Form = XmlSchemaForm.Unqualified, DataType = "string")]
        public string ExporterVersion { get; set; }
    }
}