using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn {
    public class GetValueFunc : IFunc {

        public const string FuncName = "get value";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            parameters[0].ExpectedDataType (DataTypeEnum.Context);

            parameters[0].ContextInputs.ContextDict.TryGetValue (parameters[1], out var gVal);

            return gVal;

        }
    }
}