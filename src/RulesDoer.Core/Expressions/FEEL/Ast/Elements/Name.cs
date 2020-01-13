using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class Name : IExpression {
        private readonly string _nameInput;

        public Name (string name) {
            _nameInput = name;
        }

        public object Execute (VariableContext context = null) {
            if (context != null) {

                var ctxVar = VariableContextHelper.RetrieveLocaContext (context, _nameInput, false);
                if (ctxVar != null) {
                    return ctxVar;
                }

                var funcVar = VariableContextHelper.RetrieveFunctionInput (context, _nameInput, false);
                if (funcVar != null) {
                    return funcVar;
                }

                //get the input variables first before decision names if there is overlapping name conflicts
                var outVar = VariableContextHelper.RetrieveInputVariable (context, _nameInput, false);
                if (outVar != null) {
                    return outVar;
                }

                var decisionVar = DMNDoerHelper.EvaluateDecisionByName (context, _nameInput);
                if (decisionVar != null) {
                    //all the values that override is always string variable
                    var overrideVar = VariableContextHelper.RetrieveInputVariable (context, _nameInput, false);
                    if (overrideVar != null) {
                        return VariableHelper.MakeVariable (overrideVar.StringVal, decisionVar.ValueType);
                    }
                    return decisionVar;
                }

            }

            return new Variable (_nameInput);
        }
    }
}