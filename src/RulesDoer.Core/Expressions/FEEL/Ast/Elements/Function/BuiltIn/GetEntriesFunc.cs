using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn {
    public class GetEntriesFunc : IFunc {
        public const string FuncName = "get entries";
        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (1);
            parameters[0].ExpectedDataType (DataTypeEnum.Context);

            List<Variable> entries = new List<Variable> ();
            foreach (var item in parameters[0].ContextInputs.ContextDict) {

                var cntxt = new ContextInputs ().Add ("key", item.Key).Add ("value", item.Value);
                entries.Add (cntxt);

            }

            return entries;

        }
    }
}