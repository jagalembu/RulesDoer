using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Transformer.v1_2;
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
                    if (context.DecisionServiceMetaByName.TryGetValue (outFuncName, out var decisionService)) {
                        return DMNDoerHelper.EvalDecisionService (decisionService, context, lVars);
                    }
                }

                if (Parameters is NamedParameters namedParam) {

                    if (VariableContextHelper.RetrieveBkm (outFuncName, context, out var bkmMeta)) {
                        lVars = BKMConvertNamedParameter (namedParam, bkmMeta.BKMModel, context);
                        return DMNDoerHelper.EvalBkm (bkmMeta.BKMModel, context, lVars);
                    }
                    if (context.DecisionServiceMetaByName.TryGetValue (outFuncName, out var decisionService)) {
                        lVars = DecisionServiceConvertNamedParameter (namedParam, decisionService, context);
                        return DMNDoerHelper.EvalDecisionService (decisionService, context, lVars);
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

        public static List<Variable> DecisionServiceConvertNamedParameter (NamedParameters nParam, TDecisionService decisionService, VariableContext context) {
            var variables = new List<Variable> ();
            var parameters = nParam.Execute ();
            if (parameters is Dictionary<string, IExpression> outExprs) {
                foreach (var item in decisionService.InputDecision) {
                    var decId = item.Href.TrimStart ('#');
                    context.DecisionMetaById.TryGetValue (decId, out var decision);
                    outExprs.TryGetValue (decision.Name, out var expression);
                    if (expression == null) {
                        throw new FEELException ($"Missing expected named parameter {decision.Name}");
                    }
                    if (expression != null) {
                        variables.Add ((Variable) expression.Execute (context));
                    }
                }
                return variables;
            }

            throw new FEELException ("Failed coverting named parameters");

        }

        public static List<Variable> BKMConvertNamedParameter (NamedParameters nParam, TBusinessKnowledgeModel bkmModel, VariableContext context) {
            var variables = new List<Variable> ();
            var parameters = nParam.Execute ();

            if (parameters is Dictionary<string, IExpression> outExprs) {
                foreach (var item in bkmModel.EncapsulatedLogic.FormalParameter) {
                    outExprs.TryGetValue (item.Name, out var expression);
                    if (expression == null) {
                        throw new FEELException ($"Missing expected named parameter {item.Name}");
                    }
                    if (expression != null) {
                        variables.Add ((Variable) expression.Execute (context));
                    }
                }
            }

            throw new FEELException ("Failed coverting named parameters");
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