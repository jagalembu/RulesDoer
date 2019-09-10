using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class ListLiteral : IExpression {

        private readonly List<IExpression> Expressions;

        public ListLiteral (List<IExpression> expressions) {
            Expressions = expressions;
        }

        public object Execute (VariableContext context = null) {
            List<Variable> varList = new List<Variable> ();

            //this happens when nothing is between the brackets
            if (Expressions[0] == null)
            {
                return new Variable(varList);
            }

            if (Expressions.Any ()) {
                var allSameType = true;

                var firstVar = (Variable) Expressions[0].Execute (context);
                varList.Add (firstVar);

                var firstType = firstVar.ValueType;

                for (int i = 1; i < Expressions.Count; i++) {
                    var listVar = (Variable) Expressions[i].Execute (context);
                    varList.Add (listVar);
                    if (listVar.ValueType != firstType) {
                        allSameType = false;
                    }
                }

                if (allSameType && firstType == DataTypeEnum.String) {
                    return Variable.ListType (varList, DataTypeEnum.ListString);
                }

                if (allSameType && firstType == DataTypeEnum.Decimal) {
                    return Variable.ListType (varList, DataTypeEnum.ListDecimal);
                }

                if (allSameType && firstType == DataTypeEnum.Boolean) {
                    return Variable.ListType (varList, DataTypeEnum.ListBoolean);
                }

            }

            return new Variable (varList);

        }
    }
}