using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Tests.TCK.Transformer;

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
                    throw new NotImplementedException ("TCK List inputs not supported yet");
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

    }
}