using System;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class RangeIterator : IExpression {
        private readonly IExpression _startExpr;
        private readonly IExpression _endExpr;
        private readonly string _name;

        public RangeIterator (string name, IExpression start, IExpression end) {
            _startExpr = start;
            _endExpr = end;
            _name = name;
        }
        public object Execute (VariableContext context = null) {

            var start = (Variable) _startExpr.Execute (context);

            if (_endExpr == null) {
                if (!start.IsListType ()) {
                    throw new FEELException ("Expected a list variable for iterations");
                }
                return new Variable (new ContextInputs ().Add (_name, start));

            }

            var end = (Variable) _endExpr.Execute (context);

            start.ExpectedDataType (DataTypeEnum.Decimal);
            end.ExpectedDataType (DataTypeEnum.Decimal);

            var range = RangeHelper.Decimal (start, end).ToList ();

            return new Variable (new ContextInputs ().Add (_name, Variable.ListType (range, DataTypeEnum.ListDecimal)));
        }
    }
}