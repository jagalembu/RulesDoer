using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
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

            var funcName = Function.Execute ();

            if (funcName is Variable outFuncName && outFuncName.ValueType == DataTypeEnum.String) {
                if (Parameters is PositionalParameters) {
                    var listVars = RetrieveListOfParameters ();
                    switch (listVars[0].ValueType) {
                        case DataTypeEnum.String:
                            return StringFunctions.Execute (outFuncName.StringVal, listVars);
                        case DataTypeEnum.Decimal:
                            return NumericFunctions.Execute (outFuncName.StringVal, listVars);


                    }

                }
                //TODO: do named parameters functions runs
            }

            throw new FEELException ("Function name is not a variable of string type");

        }

        private List<Variable> RetrieveListOfParameters () {
            var expressions = Parameters.Execute ();

            //TODO: future function to add input context if there is any

            var outList = new List<Variable> ();

            if (expressions is List<IExpression> outExprs) {
                foreach (var item in outExprs) {
                    outList.Add ((Variable) item.Execute ());
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