using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Xml;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class DateTimeLiteral : IExpression {

        public IExpression DateExpression { get; set; }

        public string DateFunction { get; set; }

        public DateTimeLiteral (string dateFunction, IExpression dateExpression) {
            DateFunction = dateFunction;
            DateExpression = dateExpression;
        }

        public object Execute (VariableContext context = null) {
            var dateExprVar = DateExpression.Execute ();

            if (dateExprVar is Variable dateExprOut) {
                switch (DateFunction) {
                    case "date":
                        return DateAndTimeHelper.DateVal (dateExprOut.StringVal);

                    case "date and time":
                        return DateAndTimeHelper.DateTimeVal (dateExprOut.StringVal);

                    case "time":
                        return DateAndTimeHelper.TimeVal (dateExprOut.StringVal);

                    case "duration":
                        return DateAndTimeHelper.DurationVal (dateExprOut.StringVal);

                    default:
                        throw new FEELException ($"The following date function {DateFunction} is not supported");
                }
            }

            throw new FEELException ($"Failed executing date function {DateFunction}");

        }
    }
}