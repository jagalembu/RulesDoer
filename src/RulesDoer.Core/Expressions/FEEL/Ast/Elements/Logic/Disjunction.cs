using System;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Logic {
    public class Disjunction : ILogical {
        public IExpression Left { get; private set; }
        public IExpression Right { get; private set; }

        public Disjunction (IExpression left, IExpression right) {
            Left = left;
            Right = right;
        }
        public object Execute (VariableContext context = null) {
            var leftVar = Left.Execute ();
            var rightVar = Right.Execute ();

            if (leftVar is Variable outLVar && rightVar is Variable outRVar) {
                if (outLVar.ValueType != DataTypeEnum.Boolean && outRVar.ValueType != DataTypeEnum.Boolean) {
                    throw new FEELException ($"Expected both left {outLVar.ValueType} and right {outRVar.ValueType} values to be booleans");
                }

                return new Variable (outLVar.BoolVal || outRVar.BoolVal);

            }

            throw new FEELException ("Expected both left and right values to be a variable");
        }
    }
}