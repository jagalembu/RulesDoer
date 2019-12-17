using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Statement {
    public class QuantifiedStatement : IExpression {
        private readonly string _operation;
        private readonly List<IExpression> _iterationExprs;
        private readonly IExpression _satisfyExpr;

        public QuantifiedStatement (string op, List<IExpression> iterExprs, IExpression satisfyExpr) {
            _operation = op;
            _iterationExprs = iterExprs;
            _satisfyExpr = satisfyExpr;
        }

        public object Execute (VariableContext context = null) {

            var namedList = CartesianProductHelper.BuildNamedVariableList (_iterationExprs, context);

            if (context == null) {
                context = new VariableContext ();
            }

            var dictInput = new Dictionary<string, Variable> ();
            foreach (var varList in CartesianProductHelper.IterateDynamicLoop (namedList)) {
                dictInput.Clear ();
                foreach (var item in varList) {
                    dictInput.Add (item.Item1, item.Item2);
                }
                foreach (var item in dictInput) {
                    if (!context.InputNameDict.TryAdd (item.Key, item.Value)) {
                        context.InputNameDict[item.Key] = item.Value;
                    }
                }

                bool sB = (Variable) _satisfyExpr.Execute (context);

                if ("some" == _operation && sB) {
                    return new Variable (true);
                }

                if ("every" == _operation && !sB) {
                    return new Variable (false);
                }
            }

            if ("every" == _operation) {
                return new Variable (true);
            }

            return new Variable (false);

        }

    }
}