using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class QualifiedName : IExpression {
        List<string> Names;

        public QualifiedName (List<string> names) {
            Names = names;
        }

        public object Execute (VariableContext context = null) {
            return Names;
        }
    }
}