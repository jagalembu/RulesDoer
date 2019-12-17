using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using RulesDoer.Core.Utils;

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

                var decisionVar = DMNDoerHelper.EvaluateDecisionByName (context, Names[0]);
                if (decisionVar != null) {
                    //all the values that override is always string variable
                    var overrideVar = VariableContextHelper.RetrieveInputVariable (context, Names[0], false);
                    if (overrideVar != null) {
                        return VariableHelper.MakeVariable (overrideVar.StringVal, decisionVar.ValueType);
                    }
                    return decisionVar;
                }

                return new Variable (Names[0]);
            }

            //Context parent child layers 
            var ctxVar = VariableContextHelper.RetrieveInputVariable (context, Names[0], false);

            if (ctxVar == null) {
                ctxVar = VariableContextHelper.RetrieveGlobalVariable (context, Names[0], false);
            }

            if (ctxVar == null) {
                ctxVar = DMNDoerHelper.EvaluateDecisionByName (context, Names[0]);
                //all the values that override is always string variable
                var overrideVar = VariableContextHelper.RetrieveInputVariable (context, Names[0], false);
                if (overrideVar != null) {
                    var overrideTyped = VariableHelper.MakeVariable (overrideVar.StringVal, ctxVar.ValueType);
                    ctxVar = overrideTyped;
                }

            }

            if (ctxVar == null && ctxVar.ValueType != DataTypeEnum.Context) {
                throw new FEELException ("Failed finding a context variable");
            }

            for (int i = 1; i < Names.Count; i++) {

                switch (ctxVar.ValueType) {

                    case DataTypeEnum.Context:
                        ctxVar = FindContextVariable (Names[i], ctxVar);
                        break;
                    case DataTypeEnum.Date:
                        return DateAndTimeHelper.DatePropEvals (ctxVar, Names[i]);
                    case DataTypeEnum.DateTime:
                        return DateAndTimeHelper.DateTimePropEvals (ctxVar, Names[i]);
                    case DataTypeEnum.Time:
                        return DateAndTimeHelper.TimePropEvals (ctxVar, Names[i]);
                    case DataTypeEnum.YearMonthDuration:
                    case DataTypeEnum.DayTimeDuration:
                        return DateAndTimeHelper.DurationPropEvals (ctxVar, Names[i]);
                    default:
                        throw new FEELException ($"Path expression for {ctxVar.ValueType} is not supported");
                }

            }

            return ctxVar;
        }

        private Variable FindContextVariable (string name, ContextInputs parent) {
            parent.ContextDict.TryGetValue (name, out var outVariable);

            return outVariable;
        }
    }
}