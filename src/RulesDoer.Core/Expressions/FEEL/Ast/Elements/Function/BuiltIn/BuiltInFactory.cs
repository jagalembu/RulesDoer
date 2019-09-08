using System;
using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.DateFuncs;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.NumericFuncs;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn.StringFuncs;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn {
    public static class BuiltInFactory {
        private static readonly Dictionary < string, (IFunc, string[]) > _builtFunction = new Dictionary < string, (IFunc, string[]) > () {

            { NotFunc.FuncName, (new NotFunc (), new string[] { "negand" }) }, 
            { ContainsFunc.FuncName, (new ContainsFunc (), new string[] {"string","match"}) }, 
            { EndWithFunc.FuncName, (new EndWithFunc (), new string[] {"string","match"}) }, 
            { LowerCaseFunc.FuncName, (new LowerCaseFunc (), new string[] {"string"}) }, 
            { MatchesFunc.FuncName, (new MatchesFunc (), new string[] {"input", "pattern", "flags"}) }, 
            { ReplaceFunc.FuncName, (new ReplaceFunc (), new string[] {"input", "pattern", "replacement", "flags"}) }, 
            { SplitFunc.FuncName, (new SplitFunc (), new string[] {"string","delimiter"}) }, 
            { StartsWithFunc.FuncName, (new StartsWithFunc (), new string[] {"string","match"}) }, 
            { StringFunc.FuncName, (new StringFunc (), new string[] {"from"}) }, 
            { StringLengthFunc.FuncName, (new StringLengthFunc (), new string[] {"string"}) }, 
            { SubstringAfterFunc.FuncName, (new SubstringAfterFunc (), new string[] {"string","match"}) }, 
            { SubstringBeforeFunc.FuncName, (new SubstringBeforeFunc (), new string[] {"string","match"}) }, 
            { SubstringFunc.FuncName, (new SubstringFunc (), new string[] {"string", "startposition", "length"}) }, 
            { UpperCaseFunc.FuncName, (new UpperCaseFunc (), new string[] {"string"}) }, 
            { AbsFunc.FuncName, (new AbsFunc (), new string[] {"number"}) }, 
            { CeilingFunc.FuncName, (new CeilingFunc (), new string[] {"n"}) }, 
            { DecimalFunc.FuncName, (new DecimalFunc (), new string[] {"n", "scale"}) }, 
            { EvenFunc.FuncName, (new EvenFunc (), new string[] {"number"}) },
            { ExpFunc.FuncName, (new ExpFunc (), new string[] {"number"}) }, 
            { FloorFunc.FuncName, (new FloorFunc (), new string[] {"n"}) }, 
            { LogFunc.FuncName, (new LogFunc (), new string[] {"number"}) }, 
            { ModuloFunc.FuncName, (new ModuloFunc (), new string[] {"dividend", "divisor"}) },
            { NumberFunc.FuncName, (new NumberFunc(), new string[] {"from", "groupingseparator", "decimalseparator"})}, 
            { OddFunc.FuncName, (new OddFunc (), new string[] {"number"}) }, 
            { SqrtFunc.FuncName, (new SqrtFunc (), new string[] {"number"}) },
            { DateFunc.FuncName, (new DateFunc (), new string[] {"from", "year", "month", "day"}) },
            { DateTimeFunc.FuncName, (new DateTimeFunc (), new string[] {"from", TypesConstants.Date, TypesConstants.Time}) },
            { DurationFunc.FuncName, (new DurationFunc (), new string[] {"from"}) },
            { TimeFunc.FuncName, (new TimeFunc (), new string[] {"from", "hour", "minute", "second", "offset"}) },
            { YearMonthDurationFunc.FuncName, (new YearMonthDurationFunc (), new string[] {"from", "to"}) },

        };

        public static (IFunc, string[]) GetFunc (string funcName) {
            _builtFunction.TryGetValue (funcName, out var funcMeta);

            if (funcMeta.Item1 == null) {
                throw new FEELException ($"Built in function:{funcName} not found");
            }

            return funcMeta;
        }

        public static List<Variable> ConvertNamedParameter (NamedParameters nParam, string[] validNames, VariableContext context) {
            var variables = new List<Variable> ();
            var parameters = nParam.Execute ();
            if (parameters is Dictionary<string, IExpression> outExprs) {
                foreach (var item in validNames) {
                    outExprs.TryGetValue (item, out var expression);
                    if (expression != null) {
                       variables.Add ((Variable) expression.Execute (context));
                    }
                }
                return variables;
            }

            throw new FEELException ("Failed coverting named parameters");

        }
    }
}