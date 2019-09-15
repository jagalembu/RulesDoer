using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                var itemMeta = FindDefMeta (context.ItemDefinitionMeta, null, inputMeta.TypeName);

                if (inputnode.ComponentSpecified) {

                    var ctx = MakeContextInputs (itemMeta.Name, inputnode.Component, itemMeta, context.ItemDefinitionMeta);
                    inputDicts.Add (inputnode.Name, ctx);

                } else if (inputnode.ListSpecified) {
                    var lv = MakeList (itemMeta.Name, inputnode.List, itemMeta, context.ItemDefinitionMeta);
                    inputDicts.Add (inputnode.Name, lv);

                } else {
                    if (itemMeta != null) {
                        inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, itemMeta.TypeName));
                    } else {
                        inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, inputMeta.TypeName));
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

                ctx.Add (item.Name, VariableHelper.MakeVariable (item.Value, itemComponent.TypeName));

            }

            return ctx;

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

                iL.Add (VariableHelper.MakeVariable (item.Value, curItemDefMeta.TypeName));

            }

            if (!nested) {
                return VariableHelper.MakeList (iL, curItemDefMeta.TypeName);
            }
            return iL;

        }

    }

}