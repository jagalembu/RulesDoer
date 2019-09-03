using System.Collections;
using System.Collections.Generic;
using NodaTime;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class DurationYearMonthDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "duration(\"P1Y3M\")", new PeriodBuilder { Years = 1, Months = 3 }.Build () },
            new object[] { "duration(\"-P1Y3M\")", new PeriodBuilder { Years = -1, Months = -3 }.Build () }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}