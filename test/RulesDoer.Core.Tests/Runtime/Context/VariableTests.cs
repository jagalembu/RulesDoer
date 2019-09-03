using System;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;
using Xunit;

namespace RulesDoer.Core.Tests.Runtime.Context {
    public class VariableTests {

        [Fact]
        public void Create_Decimal () {
            var dec = new decimal (1.11);
            var variable = new Variable (dec);

            Assert.Equal (dec, variable.NumericVal);
            Assert.Equal (DataTypeEnum.Decimal, variable.ValueType);
        }

        [Fact]
        public void Create_String () {

            var variable = new Variable ("my mommy hates me");

            Assert.Equal ("my mommy hates me", variable.StringVal);
            Assert.Equal (DataTypeEnum.String, variable.ValueType);

        }

        [Fact]
        public void Create_Bool () {

            var variable = new Variable (true);

            Assert.True (variable.BoolVal);
            Assert.Equal (DataTypeEnum.Boolean, variable.ValueType);

        }

        [Fact]
        public void Create_Years () {

            var variable = Variable.Years (1);
            Assert.Equal (12, variable.NumericVal);
            Assert.Equal (DataTypeEnum.YearMonthDuration, variable.ValueType);

            var variable2 = Variable.Years (1, 2);
            Assert.Equal (14, variable2.NumericVal);
            Assert.Equal (DataTypeEnum.YearMonthDuration, variable2.ValueType);

        }

        [Fact]
        public void Create_Month () {

            var variable = Variable.Months (1);
            Assert.Equal (1, variable.NumericVal);
            Assert.Equal (DataTypeEnum.YearMonthDuration, variable.ValueType);

        }

        [Fact]
        public void ImplicitOp_Decimal () {

            Variable variable = 1;
            Assert.Equal (1, variable.NumericVal);
            Assert.Equal (DataTypeEnum.Decimal, variable.ValueType);

            decimal implicitX = variable;

            Assert.Equal (1, implicitX);
        }

        [Fact]
        public void ImplicitOp_String () {

            Variable variable = "my mommy hates me";

            Assert.Equal ("my mommy hates me", variable.StringVal);
            Assert.Equal (DataTypeEnum.String, variable.ValueType);

            string implicitX = variable;

            Assert.Equal ("my mommy hates me", implicitX);

        }

        [Fact]
        public void ImplicitOp_Bool () {

            Variable variable = true;

            Assert.True (variable.BoolVal);
            Assert.Equal (DataTypeEnum.Boolean, variable.ValueType);

            bool implicitX = variable;

            Assert.True (implicitX);

        }

        [Fact]
        public void ImplicitOp_NotSupported () {

            var variable = new Variable ();

            Assert.Throws<NotSupportedException> (() => { bool b = variable; });
            Assert.Throws<NotSupportedException> (() => { string s = variable; });
            Assert.Throws<NotSupportedException> (() => { decimal d = variable; });

        }

    }
}