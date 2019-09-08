using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class FunctionInvocation : IExpression {
        IExpression Function;
        IExpression Parameters;

        public FunctionInvocation (IExpression function, IExpression parameters) {
            Function = function;
            Parameters = parameters;
        }

        public object Execute (VariableContext context = null) {

            var funcName = Function.Execute (context);

            if (funcName is Variable outFuncName && outFuncName.ValueType == DataTypeEnum.String) {
                List<Variable> lVars = new List<Variable> ();
                if (Parameters is PositionalParameters) {
                    lVars = RetrieveListOfParameters (context);
                    if (VariableContextHelper.RetrieveBkm (outFuncName, context, out var bkmMeta)) {
                        return DMNDoerHelper.EvalBkm (bkmMeta.BKMModel, context, lVars);
                    }
                }

                var funcMeta = BuiltInFactory.GetFunc (outFuncName);

                if (Parameters is NamedParameters nParam) {
                    lVars = BuiltInFactory.ConvertNamedParameter (nParam, funcMeta.Item2, context);
                }

                return funcMeta.Item1.Execute (lVars);

                // if (Parameters is PositionalParameters) {
                //     var listVars = RetrieveListOfParameters (context);

                //     //TODO: create reserved function names logic to prevent overlap function names

                //     if (VariableContextHelper.RetrieveBkm (outFuncName, context, out var bkmMeta)) {
                //         return DMNDoerHelper.EvalBkm (bkmMeta.BKMModel, context, listVars);
                //     }

                //     if (BooleanFunctions.Not_Func == outFuncName) {
                //         return BooleanFunctions.Execute (outFuncName.StringVal, listVars);
                //     }

                //     if (StringFunctions.StringFuncs.Contains (outFuncName)) {
                //         return StringFunctions.Execute (outFuncName.StringVal, listVars);
                //     }

                //     if (NumericFunctions.NumericFuncs.Contains (outFuncName)) {
                //         return NumericFunctions.Execute (outFuncName.StringVal, listVars);
                //     }

                //     if (DateFunctions.DateFuncs.Contains (outFuncName)) {
                //         return DateFunctions.Execute (outFuncName.StringVal, listVars);
                //     }

                // }

                // if (Parameters is NamedParameters) {
                //     var namedDict = RetrieveNamedParameters ();

                //     if (BooleanFunctions.Not_Func == outFuncName) {
                //         return BooleanFunctions.Execute (outFuncName.StringVal, namedDict.Values.ToList ());
                //     }

                //     if (StringFunctions.StringFuncs.Contains (outFuncName)) {
                //         return StringFunctions.Execute (outFuncName.StringVal, namedDict.Values.ToList ());
                //     }

                //     if (NumericFunctions.NumericFuncs.Contains (outFuncName)) {
                //         return NumericFunctions.Execute (outFuncName.StringVal, namedDict.Values.ToList ());
                //     }

                //     if (DateFunctions.DateFuncs.Contains (outFuncName)) {
                //         return DateFunctions.Execute (outFuncName.StringVal, namedDict.Values.ToList ());
                //     }

                // }

            }

            throw new FEELException ("Function name is not a variable of string type");

        }

        private List<Variable> RetrieveListOfParameters (VariableContext context) {
            var expressions = Parameters.Execute (context);

            var outList = new List<Variable> ();

            if (expressions is List<IExpression> outExprs) {
                foreach (var item in outExprs) {
                    outList.Add ((Variable) item.Execute (context));
                }
            }

            return outList;
        }

        private Dictionary<string, Variable> RetrieveNamedParameters () {
            var expressions = Parameters.Execute ();

            // future function to add input context if there is any

            var outDict = new Dictionary<string, Variable> ();

            if (expressions is Dictionary<string, IExpression> outExprs) {
                foreach (var item in outExprs) {
                    outDict.Add (item.Key, (Variable) item.Value.Execute ());
                }
            }

            return outDict;
        }
    }
}