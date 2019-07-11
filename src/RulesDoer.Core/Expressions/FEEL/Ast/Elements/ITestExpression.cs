using System;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public interface ITestExpression : IEle {

        bool Execute (VariableContext context = null, string inputName = null);

    }
}