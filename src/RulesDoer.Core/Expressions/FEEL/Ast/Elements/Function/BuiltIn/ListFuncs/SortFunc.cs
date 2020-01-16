using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.ListFuncs {
    public class SortFunc : IFunc {

        public const string FuncName = "sort";

        public Variable Execute (List<Variable> parameters) {
            parameters.ExpectedParamCount (2);
            parameters[1].ExpectedDataType (DataTypeEnum.Function);
            if (parameters[0].IsListType ()) {
                 parameters[0].ListVal.Sort ((v1, v2) => CompareFunc (parameters[1].UserFunction, new List<Variable> () { v1, v2 }));
                 return parameters[0];
            }

            throw new FEELException ($"Failed sort function due to incorrect type:{parameters[0].ValueType}. Expected a list type");

        }

        private  int CompareFunc (UserFunction userFunction, List<Variable> paramList) {
            var outVar = userFunction.Execute (paramList, null, null);

            if (outVar) {
                return -1;
            }
            return 1;
        }
    }
}