using System.Collections.Generic;
using System.Collections.ObjectModel;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Tests.TCK.Transformer;
using RulesDoer.Core.Types;
using Xunit;
using ValueType = RulesDoer.Core.Tests.TCK.Transformer.ValueType;

namespace RulesDoer.Core.Tests.TCK.Run {
    public class ExecuteTCK {
        private readonly DMNDoer _doer;
        private readonly TCKTransformer _transformer;
        public ExecuteTCK (DMNDoer doer, TCKTransformer transformer) {
            _doer = doer;
            _transformer = transformer;
        }

        public void RunTest (string filename, string testInput, string testName = null) {
            var tckmodel = _transformer.Transform (testInput);

            var splitNames = tckmodel.ModelName.Split ('.');

            var context = _doer.BuildContext (splitNames[0]);

            foreach (var item in tckmodel.TestCase) {
                var inputNameDict = TCKHelper.MakeInputData (item, context);
                context.InputNameDict = inputNameDict;

                if (item.Type == TestCaseType.DecisionService && item.InvocableName != null) {
                    HandleDecisionServiceTestCase (item, splitNames[0], testName);
                    continue;
                }

                foreach (var rsltNode in item.ResultNode) {
                    if (testName == null || rsltNode.Name.Contains (testName)) {

                        var rslt = _doer.EvaluateDecisions (context, splitNames[0], null, rsltNode.Name);

                        switch (rsltNode.Type) {
                            case "decision":
                            case null:
                                AssertResult (rsltNode, rslt);
                                break;
                            default:
                                throw new TCKException ($"The following TCK test type: {rsltNode.Type} is not supported");

                        }
                    }
                }
            }

        }

        private void HandleDecisionServiceTestCase (TestCasesTestCase item, string defName, string testName) {
            var runtimeContext = _doer.BuildContext (defName);

            runtimeContext.DecisionServiceMetaByName.TryGetValue (item.InvocableName, out var decisionService);
            if (decisionService == null)
                throw new TCKException ($"Decision service '{item.InvocableName}' not found");

            // Build named inputs from raw XSD types (not pre-coerced)
            var namedInputs = new Dictionary<string, Variable> ();
            foreach (var inputNode in item.InputNode) {
                namedInputs[inputNode.Name] = BuildRawVariable (inputNode);
            }

            // Order input params: InputData first, then InputDecision (caller-provided)
            var inputParams = new List<Variable> ();
            foreach (var inputDataRef in decisionService.InputData) {
                var dataId = inputDataRef.Href.TrimStart ('#');
                runtimeContext.InputDataMetaById.TryGetValue (dataId, out var inputMeta);
                if (inputMeta != null && namedInputs.TryGetValue (inputMeta.Name, out var inputVar)) {
                    inputParams.Add (inputVar);
                } else {
                    inputParams.Add (new Variable ());
                }
            }
            foreach (var inputDecRef in decisionService.InputDecision) {
                var decId = inputDecRef.Href.TrimStart ('#');
                runtimeContext.DecisionMetaById.TryGetValue (decId, out var decMeta);
                if (decMeta != null && namedInputs.TryGetValue (decMeta.Name, out var inputVar)) {
                    inputParams.Add (inputVar);
                } else {
                    inputParams.Add (new Variable ());
                }
            }

            var serviceResult = DMNDoerHelper.EvalDecisionService (decisionService, runtimeContext, inputParams);

            foreach (var rsltNode in item.ResultNode) {
                if (testName != null && !rsltNode.Name.Contains (testName)) continue;

                Variable componentResult;
                if (serviceResult != null && serviceResult.ValueType == DataTypeEnum.Context) {
                    serviceResult.ContextInputs.ContextDict.TryGetValue (rsltNode.Name, out componentResult);
                    componentResult ??= new Variable ();
                } else {
                    componentResult = new Variable ();
                }

                var rsltDict = new Dictionary<string, Variable> { { rsltNode.Name, componentResult } };
                AssertResult (rsltNode, rsltDict);
            }
        }

        private static Variable BuildRawVariable (TestCasesTestCaseInputNode inputNode) {
            if (inputNode.ListSpecified) {
                var list = new List<Variable> ();
                foreach (var listItem in inputNode.List) {
                    list.Add (TCKHelper.MakeVariableFromType (listItem.Value));
                }
                return new Variable (list);
            }
            if (inputNode.Value != null) {
                return TCKHelper.MakeVariableFromType (inputNode.Value);
            }
            return new Variable ();
        }

        private void AssertResult (TestCasesTestCaseResultNode rsltnode, Dictionary<string, Variable> actualrslt) {

            actualrslt.TryGetValue (rsltnode.Name, out var rsltVar);
            Assert.NotNull (rsltVar);

            AssertResultValueType (rsltnode.Expected, rsltnode.Name, null, rsltVar);
        }

        private void AssertResultValueType (ValueType expected, string name, Dictionary<string, Variable> actualrsltDic = null, Variable actualrslt = null) {

            if (actualrslt != null && DataTypeEnum.DecisionTableResult == actualrslt.ValueType) {
                AssertDecisionTableResult (expected, name, actualrslt.DecisionTableResult.OutputResult);
                return;
            }

            if (expected.ComponentSpecified) {
                if (actualrsltDic != null) {
                    AssertResultComponent (expected.Component, name, actualrsltDic);
                    return;
                }
                AssertResultComponent (expected.Component, name, null, actualrslt);
                return;
            }

            if (expected.ListSpecified) {
                AssertResultList (expected.List, name, null, actualrslt);
                return;
            }

            AssertResultByIndividualType (TCKHelper.GetValueType (expected.Value), actualrslt, name);

        }

        private void AssertDecisionTableResult (ValueType expected, string name, List<Dictionary<string, Variable>> actualrslts) {
            if (expected.ComponentSpecified) {
                AssertResultComponent (expected.Component, name, actualrslts[0]);
                return;
            }

            if (expected.ListSpecified) {
                AssertResultList (expected.List, name, actualrslts);
                return;
            }

            throw new TCKException ("Decision table expected component or list result");
        }

        private void AssertResultList (Collection<ValueType> expected, string name, List<Dictionary<string, Variable>> actualrsltList = null, Variable actualRslt = null) {

            for (int i = 0; i < expected.Count; i++) {
                if (actualrsltList != null) {
                    if (actualrsltList[i].Count > 1) {
                        AssertResultValueType (expected[i], name, actualrsltList[i]);
                    } else {
                        foreach (var item in actualrsltList[i].Values) {
                            AssertResultValueType (expected[i], name, null, item);
                        }
                    }

                } else {
                    if (actualRslt.IsListType ()) {
                        AssertResultValueType (expected[i], name, null, actualRslt.ListVal[i]);
                    } else {
                        AssertResultValueType (expected[i], name, null, actualRslt);
                    }

                }
            }

        }

        private void AssertResultComponent (Collection<ValueTypeComponent> expected, string name, Dictionary<string, Variable> actualRsltDict = null, Variable actualRslt = null) {

            if (actualRslt != null && actualRslt.ValueType == DataTypeEnum.Context) {
                foreach (var item in expected) {
                    actualRslt.ContextInputs.ContextDict.TryGetValue (item.Name, out var rslt);
                    AssertResultValueType (item, name, null, rslt);
                }

                return;
            }

            if (actualRsltDict != null) {
                foreach (var item in expected) {
                    actualRsltDict.TryGetValue (item.Name, out var rslt);
                    AssertResultValueType (item, name, null, rslt);
                }
                return;
            }

            throw new TCKException ("Missing variable to assert components");

        }

        private void AssertResultByIndividualType (object expected, Variable actualrslt, string name = null) {
            if (expected == null) {
                if (actualrslt.IsListType ()) {
                    Assert.True (actualrslt.ListVal.Count == 0, name);
                    return;
                }
                Assert.True (actualrslt.ValueType == DataTypeEnum.Null, name);
                return;
            }
            //singleton list
            if (actualrslt.IsListType () && actualrslt.ListVal.Count == 1) {
                Assert.Equal<Variable> (VariableHelper.MakeVariable (expected, actualrslt.ListVal[0].ValueType), actualrslt.ListVal[0]);
                return;
            }

            var expectedVar = VariableHelper.MakeVariable (expected, actualrslt.ValueType);

            // FEEL spec allows results to be compared with a relative tolerance of 1e-10
            // to accommodate different implementations using different precisions (e.g. double vs decimal).
            if (actualrslt.ValueType == DataTypeEnum.Decimal && expectedVar.NumericVal != 0m) {
                var relDiff = System.Math.Abs ((double) (actualrslt.NumericVal - expectedVar.NumericVal) / (double) expectedVar.NumericVal);
                Assert.True (relDiff < 1e-10, $"Failed asserting equal for expected:{expected} actual:{actualrslt.NumericVal} relDiff:{relDiff} for decision name:{name}");
                return;
            }

            Assert.True (expectedVar.Equals (actualrslt), $"Failed asserting equal for expected:{expected} for decision name:{name}");

        }

    }
}