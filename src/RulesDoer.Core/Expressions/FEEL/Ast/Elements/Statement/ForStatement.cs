using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Statement {
    public class ForStatement : IExpression {
        private readonly List<IExpression> _iterationExprs;
        private readonly IExpression _returnExpr;

        public ForStatement (List<IExpression> iterExpr, IExpression returnExpr) {
            _iterationExprs = iterExpr;
            _returnExpr = returnExpr;
        }

        public object Execute (VariableContext context = null) {

            var namedList = CartesianProductHelper.BuildNamedVariableList (_iterationExprs, context);

            if (context == null) {
                context = new VariableContext ();
            }

            var rsltLst = new List<Variable> ();

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

                var rslt = (Variable) _returnExpr.Execute (context);
                rsltLst.Add (rslt);
                if (!context.InputNameDict.TryAdd ("__CpL__", rsltLst)) {
                    context.InputNameDict["__CpL__"] = rsltLst;
                }
            }

            return new Variable (rsltLst);
        }
    }
}