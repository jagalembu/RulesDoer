using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public interface IExpression : IEle {
        object Execute (VariableContext context = null);
    }
}