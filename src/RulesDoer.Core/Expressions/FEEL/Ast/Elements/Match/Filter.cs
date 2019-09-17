using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Match {
    public class Filter : IExpression {
        private readonly IExpression Left;
        private readonly IExpression FilterExpression;

        public Filter (IExpression left, IExpression filterExpr) {
            Left = left;
            FilterExpression = filterExpr;
        }

        public object Execute (VariableContext context = null) {

            var leftVal = (Variable) Left.Execute (context);

            //TODO: Possible refactor using LINQ
            if (FilterExpression is Relational rel) {

                var filteredList = new List<Variable> ();
                if (leftVal.IsListType ()) {
                    var ctxt = new VariableContext ();

                    foreach (var x in leftVal.ListVal) {

                        if (x.ValueType == DataTypeEnum.Context) {
                            ctxt.InputNameDict = new Dictionary<string, Variable>(x.ContextInputs.ContextDict);
                            ctxt.InputNameDict.TryAdd ("item", x);
                        } else {
                            ctxt.InputNameDict = new Dictionary<string, Variable>() { {"item", x}};
                        }

                        //ctxt.InputNameDict.Add ("item", x);

                        var boolFiltered = (Variable) FilterExpression.Execute (ctxt);
                        if (boolFiltered.ValueType == DataTypeEnum.Boolean && boolFiltered.BoolVal == true) {
                            filteredList.Add (x);
                        }
                    }
                }
                return new Variable (filteredList);
            }

            if (!leftVal.IsListType ()) {
                switch (leftVal.ValueType) {
                    case DataTypeEnum.Boolean:
                    case DataTypeEnum.Date:
                    case DataTypeEnum.DateTime:
                    case DataTypeEnum.Decimal:
                    case DataTypeEnum.String:
                    case DataTypeEnum.Time:
                    case DataTypeEnum.YearMonthDuration:
                    case DataTypeEnum.DayTimeDuration:
                    case DataTypeEnum.Context:
                        leftVal = new Variable (new List<Variable> () { leftVal });
                        break;
                    default:
                        throw new FEELException ($"Single item filter does not support this type:{leftVal.ValueType}");
                }
            }

            var fExpr = (Variable) FilterExpression.Execute (context);

            if (leftVal.IsListType ()) {
                switch (fExpr.ValueType) {
                    case DataTypeEnum.Boolean:
                        if (fExpr.BoolVal == true) {
                            return new Variable (leftVal.ListVal.GetRange (0, leftVal.ListVal.Count));
                        }
                        return new Variable (new List<Variable> ());
                    case DataTypeEnum.Decimal:
                        if (fExpr.NumericVal == 0) {
                            throw new FEELException ("Filter position of zero is not supported for list variables");
                        }
                        if (fExpr.NumericVal > 0) {
                            var i = fExpr.NumericVal - 1;
                            return leftVal.ListVal[(int) i];
                        }
                        var l = leftVal.ListVal.Count + fExpr.NumericVal;
                        return leftVal.ListVal[(int) l];
                    default:
                        throw new FEELException ($"The following type of filter expression is not supported");
                }

            }
            throw new FEELException ($"Failed filter expression");

        }
    }
}