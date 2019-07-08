using System;
using System.Collections;
using System.Collections.Generic;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class DurationFunctionDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "duration(\"P13DT2H14S\")", new TimeSpan (13, 2, 0, 14) },
            new object[] { "duration(\"-P13DT2H14S\")", new TimeSpan (-13, -2, 0, -14) }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}