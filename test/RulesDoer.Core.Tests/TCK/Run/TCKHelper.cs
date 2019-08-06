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
                    throw new NotImplementedException ("TCK Component inputs not supported yet");
                } else if (inputnode.ListSpecified) {
                    throw new NotImplementedException ("TCK List inputs not supported yet");
                } else {
                    context.InputDataMetaByName.TryGetValue (inputnode.Name, out InputDataMeta inputMeta);
                    inputDicts.Add (inputnode.Name, VariableHelper.MakeVariable (inputnode.Value, inputMeta.TypeName));
                }

            }

            return inputDicts;
        }

    }
}