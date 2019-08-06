using System.Collections.Generic;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Tests.TCK.Transformer;
using RulesDoer.Core.Types;
using Xunit;

namespace RulesDoer.Core.Tests.TCK.Run {
    public class ExecuteTCK {
        private readonly DMNDoer _doer;
        private readonly TCKTransformer _transformer;
        public ExecuteTCK (DMNDoer doer, TCKTransformer transformer) {
            _doer = doer;
            _transformer = transformer;
        }

        public void RunTest (string testInput) {
            var tckmodel = _transformer.Transform (testInput);

            var splitNames = tckmodel.ModelName.Split ('.');

            var metaDef = _doer.BuildInputMeta (splitNames[0]);

            foreach (var item in tckmodel.TestCase) {
                var inputdict = new Dictionary<string, Variable> ();

                var context = new VariableContext () { InputNameDict = TCKHelper.MakeInputData (item, metaDef.Item1) };

                foreach (var rsltNode in item.ResultNode) {
                    var rslt = _doer.EvaluateDecisions (context, splitNames[0], null, rsltNode.Name);

                    switch (rsltNode.Type) {
                        case "decision":
                            AssertResult (rsltNode, rslt);
                            break;
                        default:
                            throw new TCKException ($"The following TCK test type: {rsltNode.Type} is not supported");

                    }

                }

            }

        }

        private void AssertResult (TestCasesTestCaseResultNode rsltnode, Dictionary<string, Variable> actualrslt) {

            actualrslt.TryGetValue (rsltnode.Name, out var rsltVar);
            Assert.NotNull (rsltVar);

            switch (rsltVar.ValueType) {
                case DataTypeEnum.Boolean:
                case DataTypeEnum.Date:
                case DataTypeEnum.DateTime:
                case DataTypeEnum.DayTimeDuration:
                case DataTypeEnum.YearMonthDuration:
                case DataTypeEnum.Decimal:
                case DataTypeEnum.String:
                    AssertResultByIndividualType (rsltnode.Expected.Value, rsltVar);
                    break;

                case DataTypeEnum.DecisionTableResult:
                case DataTypeEnum.List:
                default:
                    throw new TCKException ("Not implemented result matching");
            }

        }

        private void AssertResultByIndividualType (object expected, Variable actualrslt) {

            Assert.Equal<Variable> (VariableHelper.MakeVariable (expected, actualrslt.ValueType), actualrslt);

        }

    }
}