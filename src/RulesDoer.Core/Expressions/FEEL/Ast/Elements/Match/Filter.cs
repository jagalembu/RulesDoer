using System;
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
                    if (context == null) {
                        context = new VariableContext ();
                    }

                    var nwDict = new Dictionary<string, Variable> ();

                    foreach (var x in leftVal.ListVal) {

                        //"item" is a keyword for filtering list or context

                        if (x.ValueType == DataTypeEnum.Context) {
                            context.AddToInputDict (x.ContextInputs.ContextDict);
                            if (!x.ContextInputs.ContextDict.ContainsKey ("item")) {
                                context.AddToInputDict ("item", x);
                            }
                        } else {
                            context.AddToInputDict ("item", x);
                        }

                        var boolFiltered = (Variable) FilterExpression.Execute (context);
                        if (boolFiltered.ValueType == DataTypeEnum.Boolean && boolFiltered.BoolVal == true) {
                            filteredList.Add (x);
                        }
                    }
                }
                return new Variable (filteredList);
            }

            //for partial processing of cartesean product from For or Quantified statements
            if (leftVal.ValueType == DataTypeEnum.String && leftVal.StringVal == "partial") {
                context.InputNameDict.TryGetValue ("__CpL__", out var cpList);

                var numericVal = (Variable) FilterExpression.Execute (context);
                numericVal.ExpectedDataType (DataTypeEnum.Decimal);

                if (numericVal.NumericVal > -1) {
                    throw new FEELException ("for loop partial[] construct only allows negative values");
                }
                var curIndex = cpList.ListVal.Count + Decimal.ToInt32 (numericVal.NumericVal);
                if (curIndex < 0) {
                    throw new FEELException ($"Current index value cannot be a negative value: {curIndex}");
                }
                return cpList.ListVal[curIndex];

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