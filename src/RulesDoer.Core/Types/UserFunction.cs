using System;
using System.Collections.Generic;
using System.Linq;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Types {
    public class UserFunction {
        private readonly List<Variable> _formalParams;
        private readonly IExpression _body;
        private readonly bool _isExternal;

        public UserFunction (List<Variable> formalParams, IExpression body, bool isExternal) {
            _formalParams = formalParams;
            _body = body;
            _isExternal = isExternal;
        }

        public Variable Execute (List<Variable> inputParams, VariableContext mainContext, NamedParameters nParams = null) {

            if (_isExternal) {
                //TODO: add error logging for no support for external java/PMML function types
                return new Variable ();
            }

            var context = mainContext ?? new VariableContext ();

            if (nParams != null) {
                inputParams = BuiltInFactory.ConvertNamedParameter (nParams, _formalParams.Select (v => v.TwoTuple.a.StringVal).ToArray (), context);
            }

            if (inputParams != null && _formalParams.Count > 0) {
                if (_formalParams.Count != inputParams.Count) {
                    //TODO: Add to error logging for missmatch expected input
                    return new Variable ();
                }

                for (int i = _formalParams.Count - 1; i >= 0; i--) {
                    context.AddToFunctionInputs (_formalParams[i].TwoTuple.a.StringVal, inputParams[i]);
                }

            }

            try {
                return (Variable) _body.Execute (context);
            } catch (Exception) {
                return new Variable ();
            }
        }
    }
}