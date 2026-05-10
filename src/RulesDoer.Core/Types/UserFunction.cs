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
        private readonly string _javaClass;
        private readonly string _javaMethodSig;

        public UserFunction (List<Variable> formalParams, IExpression body, bool isExternal) {
            _formalParams = formalParams;
            _body = body;
            _isExternal = isExternal;
        }

        public UserFunction (List<Variable> formalParams, string javaClass, string javaMethodSig) {
            _formalParams = formalParams;
            _javaClass = javaClass;
            _javaMethodSig = javaMethodSig;
            _isExternal = true;
        }

        public Variable Execute (List<Variable> inputParams, VariableContext mainContext, NamedParameters nParams = null) {

            if (_isExternal) {
                if (_javaClass != null) {
                    return Runtime.JavaExternalInvoker.Invoke (_javaClass, _javaMethodSig, inputParams ?? new List<Variable> ());
                }
                // FEEL literal external form: evaluate body to extract {java:{class:"...",method signature:"..."}}
                try {
                    var configVar = (Variable) _body.Execute (new VariableContext ());
                    if (configVar?.ValueType != DataTypeEnum.Context) return new Variable ();
                    configVar.ContextInputs.ContextDict.TryGetValue ("java", out var javaCtx);
                    if (javaCtx?.ValueType != DataTypeEnum.Context) return new Variable ();
                    javaCtx.ContextInputs.ContextDict.TryGetValue ("class", out var classVar);
                    javaCtx.ContextInputs.ContextDict.TryGetValue ("method signature", out var methodSigVar);
                    var javaClass = classVar?.StringVal;
                    var javaMethodSig = methodSigVar?.StringVal;
                    if (javaClass == null || javaMethodSig == null) return new Variable ();
                    return Runtime.JavaExternalInvoker.Invoke (javaClass, javaMethodSig, inputParams ?? new List<Variable> ());
                } catch {
                    return new Variable ();
                }
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
                    var paramName = _formalParams[i].TwoTuple.a.StringVal;
                    var paramVal = inputParams[i] ?? new Variable ();
                    var paramTypeRef = _formalParams[i].TwoTuple.b?.StringVal;
                    if (!string.IsNullOrEmpty (paramTypeRef)) {
                        paramVal = Runtime.TypeCoercionHelper.Coerce (paramVal, paramTypeRef, context?.ItemDefinitionMeta);
                    }
                    context.AddToFunctionInputs (paramName, paramVal);
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