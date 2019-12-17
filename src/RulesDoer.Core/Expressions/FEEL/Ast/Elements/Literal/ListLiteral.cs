using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal {
    public class ListLiteral : IExpression {

        public List<IExpression> Expressions { get; set; }

        public ListLiteral (List<IExpression> expressions) {
            Expressions = expressions;
        }

        public object Execute (VariableContext context = null) {
            List<Variable> varList = new List<Variable> ();

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
                    if (context != null && context.LocalContext != null) {
                        context.LocalContext = null;
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