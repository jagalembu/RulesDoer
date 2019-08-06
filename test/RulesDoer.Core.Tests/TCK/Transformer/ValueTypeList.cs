namespace RulesDoer.Core.Tests.TCK.Transformer
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ValueTypeList", Namespace="http://www.omg.org/spec/DMN/20160719/testcase", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ValueTypeList
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<ValueType> _item;
        
        [System.Xml.Serialization.XmlElementAttribute("item", Namespace="http://www.omg.org/spec/DMN/20160719/testcase")]
        public System.Collections.ObjectModel.Collection<ValueType> Item
        {
            get
            {
                return this._item;
            }
            private set
            {
                this._item = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ItemSpecified
        {
            get
            {
                return (this.Item.Count != 0);
            }
        }
        
        public ValueTypeList()
        {
            this._item = new System.Collections.ObjectModel.Collection<ValueType>();
        }
    }
}