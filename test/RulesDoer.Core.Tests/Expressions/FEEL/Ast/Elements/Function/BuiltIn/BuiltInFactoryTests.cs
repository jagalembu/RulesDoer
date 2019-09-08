using System.Collections.Generic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function.BuiltIn;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using Xunit;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Ast.Elements.Function.BuiltIn {
    public class BuiltInFactoryTests {
        [Fact]
        public void Function_Found () {

            var lVars = new List<Variable> ();
            lVars.Add (true);

            var funcMeta = BuiltInFactory.GetFunc (NotFunc.FuncName);

            var boolVar = funcMeta.Item1.Execute (lVars);

            Assert.False (boolVar);
        }

        [Fact]
        public void Function_NotFound_Error () {

            Assert.Throws<FEELException> (() => BuiltInFactory.GetFunc ("x"));

        }

        [Fact]
        public void ConvertNamedParameters_Names_Matched () {

            var funcMeta = BuiltInFactory.GetFunc (NotFunc.FuncName);

            var nParamDict = new Dictionary<string, IExpression> () { { "negand", new BooleanLiteral ("true") } };
            var namedP = new NamedParameters (nParamDict);

            var lParams = BuiltInFactory.ConvertNamedParameter (namedP, funcMeta.Item2, null);

            var boolVar = funcMeta.Item1.Execute (lParams);

            Assert.False (boolVar);

        }


        [Fact]
        public void ConvertNamedParameters_Failed () {

            var funcMeta = BuiltInFactory.GetFunc (NotFunc.FuncName);

            var namedP = new NamedParameters (null);

            var err = Assert.Throws<FEELException> (() => BuiltInFactory.ConvertNamedParameter (namedP, funcMeta.Item2, null));

            Assert.Equal("Failed coverting named parameters", err.Message);

        }

    }
}