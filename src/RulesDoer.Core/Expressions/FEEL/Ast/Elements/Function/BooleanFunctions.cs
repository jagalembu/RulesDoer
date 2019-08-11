using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function
{
    public static class BooleanFunctions
    {
        public const string Not_Func = "not";
        
        public static Variable Execute (string functionName, List<Variable> parameters) {
            switch (functionName) {
                case Not_Func:
                    return !parameters[0];

                default:
                    return new Variable ();
            }
        }
        
    }
}