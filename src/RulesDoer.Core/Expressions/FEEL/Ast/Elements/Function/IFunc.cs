using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public interface IFunc {
        public Variable Execute (List<Variable> parameters);
    }
}