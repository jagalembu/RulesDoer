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

    }
}