using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class UserDefinedFunction : IExpression {
        private readonly List<IExpression> _params;
        private readonly IExpression _body;
        private readonly bool _isExternal = false;

        public UserDefinedFunction (List<IExpression> @params, IExpression body, bool isExternal) {
            _params = @params;
            _body = body;
            _isExternal = isExternal;
        }

        public object Execute (VariableContext context = null) {
            var paramList = new List<Variable> ();
            Variable paramVar;
            foreach (var item in _params) {
                paramVar = (Variable) item.Execute (context);
                paramList.Add (paramVar);
            }
            return new Variable (new UserFunction (paramList, _body, _isExternal));
        }
    }
}