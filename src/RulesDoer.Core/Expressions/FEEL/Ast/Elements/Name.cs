using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class Name : IExpression {
        string NameInput;

        public Name (string name) {
            NameInput = name;
        }

        public object Execute (VariableContext context = null) {
            if (context != null) {

                var ctxVar = VariableContextHelper.RetrieveLocaContext (context, NameInput, false);
                if (ctxVar != null) {
                    return ctxVar;
                }

                //get the input variables first before decision names if there is overlapping name conflicts
                var outVar = VariableContextHelper.RetrieveInputVariable (context, NameInput, false);
                if (outVar != null) {
                    return outVar;
                }

                var decisionVar = DMNDoerHelper.EvaluateDecisionByName (context, NameInput);
                if (decisionVar != null) {
                    //all the values that override is always string variable
                    var overrideVar = VariableContextHelper.RetrieveInputVariable (context, NameInput, false);
                    if (overrideVar != null) {
                        return VariableHelper.MakeVariable (overrideVar.StringVal, decisionVar.ValueType);
                    }
                    return decisionVar;
                }                

            }

            return new Variable (NameInput);
        }
    }
}