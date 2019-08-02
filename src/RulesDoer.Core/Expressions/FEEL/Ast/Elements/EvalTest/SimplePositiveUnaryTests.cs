using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class SimplePositiveUnaryTests : ITestExpression {
        private readonly List<ITestExpression> Expressions;

        public SimplePositiveUnaryTests (List<ITestExpression> expressions) {
            Expressions = expressions;
        }

        public object Execute (VariableContext context = null, string inputName = null) {
            foreach (var item in Expressions) {
                if (((Variable)item.Execute (context, inputName)).BoolVal == true) {
                    return new Variable(true);
                }
            }

            return new Variable(false);
        }
    }
}