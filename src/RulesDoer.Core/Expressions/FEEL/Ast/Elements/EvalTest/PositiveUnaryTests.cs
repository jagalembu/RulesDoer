using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class PositiveUnaryTests : ITestExpression {
        private readonly List<ITestExpression> Expressions;

        public PositiveUnaryTests (List<ITestExpression> expressions) {
            Expressions = expressions;
        }

        public bool Execute (VariableContext context = null, string inputName = null) {

            foreach (var item in Expressions) {
                if (!item.Execute (context, inputName)) {
                    return false;
                }
            }

            return true;
        }
    }
}