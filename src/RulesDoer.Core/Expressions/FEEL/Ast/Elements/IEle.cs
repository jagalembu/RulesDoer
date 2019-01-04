using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast {
    public interface IEle {
        void Execute (IAstVisitor visitor);
    }
}