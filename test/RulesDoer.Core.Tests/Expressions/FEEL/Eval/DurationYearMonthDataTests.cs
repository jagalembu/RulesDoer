using System.Collections;
using System.Collections.Generic;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class DurationYearMonthDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "duration(\"P1Y3M\")", new decimal (15) },
            new object[] { "duration(\"-P1Y3M\")", new decimal (-15) }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}