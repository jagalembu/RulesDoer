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

        //  a    b  a and b a or b
        // true true true true
        // true false false true
        // true otherwise null true
        // false true false true
        // false false false false
        // false otherwise false null
        // otherwise true null true
        // otherwise false false null
        // otherwise otherwise null null 
        public object Execute (VariableContext context = null) {
            var leftVar = Left.Execute (context);
            var rightVar = Right.Execute (context);

            if (leftVar is Variable outLVar && rightVar is Variable outRVar) {
                if (outLVar.ValueType == DataTypeEnum.Boolean && outRVar.ValueType == DataTypeEnum.Boolean) {
                    return new Variable (outLVar.BoolVal || outRVar.BoolVal);
                }
                if (outLVar.ValueType == DataTypeEnum.Boolean && outLVar.BoolVal == true) {
                    return new Variable (true);
                }
                if (outRVar.ValueType == DataTypeEnum.Boolean && outRVar.BoolVal == true) {
                    return new Variable (true);
                }

                return new Variable ();
            }

            throw new FEELException ("Expected both left and right values to be a variable");
        }
    }
}