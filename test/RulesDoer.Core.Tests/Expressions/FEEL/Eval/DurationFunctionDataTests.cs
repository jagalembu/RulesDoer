using System;
using System.Collections;
using System.Collections.Generic;
using NodaTime;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class DurationFunctionDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "duration(\"P13DT2H14S\")", new PeriodBuilder { Days = 13, Hours = 2, Seconds = 14 }.Build () },
            new object[] { "duration(\"-P13DT2H14S\")", new PeriodBuilder { Days = -13, Hours = -2, Seconds = -14 }.Build () }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}