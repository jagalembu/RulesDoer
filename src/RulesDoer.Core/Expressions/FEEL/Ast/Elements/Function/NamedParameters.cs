using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class NamedParameters : IExpression {
        Dictionary<string, IExpression> Parameters;

        public NamedParameters (Dictionary<string, IExpression> parameters) {
            Parameters = parameters;
        }

        public object Execute (VariableContext context = null) {
            return Parameters;
        }
    }
}