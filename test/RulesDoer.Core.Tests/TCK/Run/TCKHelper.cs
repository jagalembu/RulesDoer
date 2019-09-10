using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Tests.TCK.Transformer;
using ValueType = RulesDoer.Core.Tests.TCK.Transformer.ValueType;

namespace RulesDoer.Core.Tests.TCK.Run {
    public static class TCKHelper {

        public static Dictionary<string, Variable> MakeInputData (TestCasesTestCase testCase, VariableContext context) {
            var inputDicts = new Dictionary<string, Variable> ();

            foreach (var inputnode in testCase.InputNode) {
                if (inputnode.ComponentSpecified) {
                    context.InputDataMetaByName.TryGetValue (inputnode.Name, out InputDataMeta inputMeta);
                    context.ItemDefinitionMeta.TryGetValue (inputMeta.TypeName, out var itemMeta);
                    var ctx = new ContextInputs (inputnode.Name);
                    ctx.IsItemDefinition = true;
                    var itemDict = new Dictionary<string, Variable> ();
                    foreach (var item in inputnode.Component) {
                        itemMeta.ItemComponents.TryGetValue (item.Name, out var itemComponent);
                        ctx.Add (item.Name, VariableHelper.MakeVariable (item.Value, itemComponent.TypeName));

                    }
                    inputDicts.Add (inputnode.Name, ctx);

                } else if (inputnode.ListSpecified) {
                    context.InputDataMetaByName.TryGetValue (inputnode.Name, out InputDataMeta inputMeta);

                    var itemMeta = FindDefMeta (context.ItemDefinitionMeta, inputMeta.TypeName);
                    //context.ItemDefinitionMeta.TryGetValue (inputMeta.TypeName, out var itemMeta);
                    if (itemMeta.IsCollection) {
                        var typeName = itemMeta.TypeName;
                        // var iL = new List<Variable> ();
                        // foreach (var item in inputnode.List) {
                        //     iL.Add (VariableHelper.MakeVariable (item.Value, typeName));
                        // }
                        inputDicts.Add (inputnode.Name, CreateList (inputnode.List, typeName));
                    } else {
                        throw new TCKException ("TCK List input is missing item definition meta type");
                    }

                } else {
                    context.InputDataMetaByName.TryGetValue (inputnode.Name, out InputDataMeta inputMeta);
                    if (context.ItemDefinitionMeta != null) {
                        context.ItemDefinitionMeta.TryGetValue (inputMeta.TypeName, out var itemMeta);
                        if (itemMeta != null) {
                            inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, itemMeta.TypeName));
                        } else {
                            inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, inputMeta.TypeName));
                        }
                    } else {
                        inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, inputMeta.TypeName));
                    }

                }

            }

            return inputDicts;
        }

        private static ItemDefinitionMeta FindDefMeta (Dictionary<string, ItemDefinitionMeta> itemDefMetaDict, string typeName) {
            itemDefMetaDict.TryGetValue (typeName, out var itemMeta);

            if (VariableHelper.IsBaseTypes (itemMeta.TypeName)) {
                return itemMeta;
            }

            return FindDefMeta (itemDefMetaDict, itemMeta.TypeName);

        }

        private static Variable CreateList (Collection<ValueType> list, string typeName) {
            var iL = new List<Variable> ();
            var nestedList = false;
            foreach (var item in list) {
                if (item.ListSpecified) {
                    nestedList = true;
                    var lVars = CreateList (item.List, typeName);
                    iL.Add (lVars);
                } else {
                    iL.Add (VariableHelper.MakeVariable (item.Value, typeName));
                }
            }

            if (nestedList) {
                return VariableHelper.MakeList (iL, "List");
            }

            return VariableHelper.MakeList (iL, typeName);
        }

    }

}