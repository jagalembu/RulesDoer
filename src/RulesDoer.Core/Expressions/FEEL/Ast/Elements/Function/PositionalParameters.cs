using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class PositionalParameters : IExpression {

        List<IExpression> Parameters;

        public PositionalParameters (List<IExpression> parameters) {
            Parameters = parameters;
        }

        public object Execute (VariableContext context = null) {
            return Parameters;
        }
    }
}