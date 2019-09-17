using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Eval;
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
            var e1 = (Variable) Input.Execute (context);

            //e1 in [e2,e3,...] || e1 = e2 or e1 = e3 or... || e2 and e3 are endpoints
            //e1 in [e2,e3,...] || e1 in e2 or e1 in e3 or... || e2 and e3 are ranges
            // e1 in <=e2 || e1 <= e2
            // e1 in <e2 || e1 < e2
            // e1 in >=e2 || e1 >= e2
            // e1 in <e2 || e1 < e2
            // e1 in (e2..e3) || e1 > e2 and e1<e3
            // e1 in (e2..e3] || e1 > e2 and e1<=e3
            // e1 in [e2..e3) || e1 >= e2 and e1<e3
            // e1 in [e2..e3] || e1 >= e2 and e1<=e3
            // e1 in e2 || e1 = e2 || e2 is a qualified name that does not evaluate to a list
            // e1 in e2 || list contains( e2, e1 ) || e1 is a simple value that is not a list and e2 is a qualified name that evaluates to a list
            // e1 in e2 || { ? : e1, r : e2 }.r || e2 is a boolean expression that uses the special variable “?”
            if (Expressions is PositiveUnaryTest posTest )
            {
                context.InputNameDict.Add("__e1__", e1);
                return (Variable)posTest.Execute(context, "__e1__");
            }

            if (Expressions is PositiveUnaryTests posTests )
            {
                context.InputNameDict.Add("__e1__", e1);
                return (Variable)posTests.Execute(context, "__e1__");
            }
            
            // if (Expressions is PositiveUnaryTest posTest)
            // {
            //     var e2 = (Variable)posTest.Execute(context);
            //     if (!e2.IsListType())
            //     {
            //         throw new FEELException($"In operation expected the list for comparison but found:{e2.ValueType}");
            //     }

            //     foreach (var item in e2.ListVal)
            //     {
            //         if (item.Equals(e1))
            //         {
            //             return true;
            //         }
            //     }
            // }

            throw new FEELException("Failed In expression");
        }
    }
}