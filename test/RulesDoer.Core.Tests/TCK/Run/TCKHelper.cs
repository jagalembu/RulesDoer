using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Tests.TCK.Transformer;
using RulesDoer.Core.Types;
using ValueType = RulesDoer.Core.Tests.TCK.Transformer.ValueType;

namespace RulesDoer.Core.Tests.TCK.Run {
    public static class TCKHelper {

        public static Dictionary<string, Variable> MakeInputData (TestCasesTestCase testCase, VariableContext context) {
            var inputDicts = new Dictionary<string, Variable> ();

            foreach (var inputnode in testCase.InputNode) {
                context.InputDataMetaByName.TryGetValue (inputnode.Name, out InputDataMeta inputMeta);
                //an overwrite input data for a decision invocation
                if (inputMeta == null) {

                    inputDicts.Add (inputnode.Name, MakeVariableFromType (inputnode.Value));
                    continue;
                }
                var itemMeta = FindDefMeta (context.ItemDefinitionMeta, null, inputMeta.TypeName);

                if (inputnode.ComponentSpecified) {

                    var ctx = MakeContextInputs (itemMeta.Name, inputnode.Component, itemMeta, context.ItemDefinitionMeta);
                    inputDicts.Add (inputnode.Name, ctx);

                } else if (inputnode.ListSpecified) {
                    var lv = MakeList (itemMeta.Name, inputnode.List, itemMeta, context.ItemDefinitionMeta);
                    inputDicts.Add (inputnode.Name, lv);

                } else {
                    if (itemMeta != null) {
                        inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (GetValueType (inputnode.Value), itemMeta.TypeName));
                    } else {
                        inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (GetValueType (inputnode.Value), inputMeta.TypeName));
                    }

                }

            }

            return inputDicts;
        }

        private static ItemDefinitionMeta FindDefMeta (Dictionary<string, ItemDefinitionMeta> itemDefMetaDict, ItemDefinitionMeta currMeta, string typeName) {

            ItemDefinitionMeta itemMeta = null;

            if (currMeta != null) {
                currMeta.ItemComponents.TryGetValue (typeName, out var currMetaFnd);
                itemMeta = currMetaFnd;
                if (currMetaFnd == null) {
                    itemDefMetaDict.TryGetValue (typeName, out var mainMetaFnd);
                    itemMeta = mainMetaFnd;
                }

            } else {
                itemDefMetaDict.TryGetValue (typeName, out var mainMetaFnd);
                itemMeta = mainMetaFnd;
            }

            if (itemMeta == null) {
                return null;
            }

            if (itemMeta.TypeName == null || VariableHelper.IsBaseTypes (itemMeta.TypeName)) {
                return itemMeta;
            }

            return FindDefMeta (itemDefMetaDict, itemMeta, itemMeta.TypeName);

        }

        private static ContextInputs MakeContextInputs (string name, Collection<ValueTypeComponent> component, ItemDefinitionMeta curItemDefMeta, Dictionary<string, ItemDefinitionMeta> itemDefMetaDict) {

            var ctx = new ContextInputs (name);
            ctx.IsItemDefinition = true;

            foreach (var item in component) {
                var itemComponent = FindDefMeta (itemDefMetaDict, curItemDefMeta, item.Name);

                if (item.ComponentSpecified) {
                    var nestedCtx = MakeContextInputs (item.Name, item.Component, itemComponent, itemDefMetaDict);
                    ctx.Add (item.Name, nestedCtx);

                }

                if (item.ListSpecified) {
                    var nestedList = MakeList (item.Name, item.List, itemComponent, itemDefMetaDict);
                    ctx.Add (item.Name, nestedList);
                }

                if (itemComponent.TypeName == null) {
                    throw new TCKException ($"Missing type name for for component:{item.Name}");
                }

                ctx.Add (item.Name, VariableHelper.MakeVariable (GetValueType (item.Value), itemComponent.TypeName));

            }

            return ctx;

        }

        public static string GetValueType (string value) {
            if (value == null) {
                return null;
            }
            return value;
        }

        public static string GetValueType (Value value) {
            if (value == null) {
                return null;
            }
            //where string and null is actually an empty string
            if (value.Type != null && value.Type.Contains ("string") && value.Val == null) {
                return "";
            }
            return value.Val;
        }

        public static string GetValueType (XmlNode value) {
            if (value == null) {
                return null;
            }
            // where string and null is actually an empty string
            // if (value.Type != null && value.Type.Contains ("string") && value.Val == null) {
            //     return "";
            // }
            return value.Value;
        }

        public static Variable MakeVariableFromType (string value) {
            if (value == null) {
                return new Variable ();
            }

            var val = GetValueType (value);

            if (val == null) {
                return null;
            }

            return VariableHelper.MakeVariable (val, "string");

        }

        public static Variable MakeVariableFromType (XmlNode value) {
            if (value == null) {
                return new Variable ();
            }

            var val = GetValueType (value);

            if (val == null) {
                return null;
            }

            return VariableHelper.MakeVariable (val, "string");

        }

        public static Variable MakeVariableFromType (Value value) {
            if (value == null) {
                return new Variable ();
            }

            var val = GetValueType (value);

            if (val == null) {
                return null;
            }

            if (value.Type != null) {
                //clean type name
                var typeName = value.Type;
                if (value.Type.Contains (":")) {

                    var typeNames = typeName.Split (':');

                    typeName = typeNames[1];
                }

                //call make variable
                return VariableHelper.MakeVariable (val, typeName);

            }

            //default to string variable
            return val;

        }

        private static Variable MakeList (string name, Collection<ValueType> listItems, ItemDefinitionMeta curItemDefMeta, Dictionary<string, ItemDefinitionMeta> itemDefMetaDict) {

            var iL = new List<Variable> ();

            var nested = false;

            foreach (var item in listItems) {
                if (item.ComponentSpecified) {
                    var nestedCtx = MakeContextInputs (name, item.Component, curItemDefMeta, itemDefMetaDict);
                    iL.Add (nestedCtx);
                    nested = true;
                    continue;

                }

                if (item.ListSpecified) {
                    var nestedList = MakeList (name, item.List, curItemDefMeta, itemDefMetaDict);
                    iL.Add (nestedList);
                    nested = true;
                    continue;
                }

                if (curItemDefMeta.TypeName == null) {
                    throw new TCKException ($"Missing type name for for item definition:{item.Value}");
                }

                iL.Add (VariableHelper.MakeVariable (GetValueType (item.Value), curItemDefMeta.TypeName));

            }

            if (!nested) {
                return VariableHelper.MakeList (iL, curItemDefMeta.TypeName);
            }
            return iL;

        }

    }

}