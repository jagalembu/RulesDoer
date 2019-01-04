using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math {
    public interface IMathExpression : IExpression {
        IExpression Left { get; set; }
        IExpression Right { get; set; }

    }
}