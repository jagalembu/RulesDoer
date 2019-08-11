using System;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison {
    public class In : IComparisonExpression {

        public readonly IExpression Input;
        public readonly IEle Expressions;

        public In (IExpression input, IEle expressions) {
            Expressions = expressions;
            Input = input;
        }

        public object Execute (VariableContext context = null) {
            var inputval = (Variable) Input.Execute (context);

            //TODO: hanlde test literal expressions
            // var inVal = (Variable) item.Execute (context);
            // if (inputval.Equals (inVal)) {
            //     return new Variable (true);
            // }

            return new Variable (false);
        }
    }
}