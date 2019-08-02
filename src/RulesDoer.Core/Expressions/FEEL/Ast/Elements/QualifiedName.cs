using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements {
    public class QualifiedName : IExpression {
        List<string> Names;

        public QualifiedName (List<string> names) {
            Names = names;
        }

        public object Execute (VariableContext context = null) {

            if (Names.Count == 1) {
                var outVar = VariableContextHelper.RetrieveInputVariable (context, Names[0], false);
                if (outVar != null) {
                    return outVar;
                }
                outVar = VariableContextHelper.RetrieveGlobalVariable (context, Names[0], false);
                if (outVar != null) {
                    return outVar;
                }
                return new Variable(Names[0]);
            }
            //TODO: get context layers of variables parent child information
            throw new FEELException ("Not implemented qualifed names search on context");

        }
    }
}