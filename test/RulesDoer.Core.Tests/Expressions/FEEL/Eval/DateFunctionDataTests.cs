using System;
using System.Collections;
using System.Collections.Generic;
using NodaTime;
using RulesDoer.Core.Utils;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class DateFunctionDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "date(\"2015-12-24\")", new LocalDate (2015, 12, 24) },
            new object[] { "date and time(\"2016-12-24T23:59:00-08:00\")", DateAndTimeHelper.DateTimeVal ("2016-12-24T23:59:00-08:00") },
            new object[] { "time(\"00:00:01\")", DateAndTimeHelper.TimeVal ("00:00:01") }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}