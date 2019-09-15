using System.Collections;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class ListFilterTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "[1,2,3][item >= 2]", new Variable (new List<Variable> () { 2, 3 }) },
            new object[] { "[{a: 1}, {a: 2}, {a: 3}][item.a >= 2]", new Variable (new List<Variable> () { new ContextInputs ().Add ("a", 2), new ContextInputs ().Add ("a", 3) }) },
            new object[] { "[{a: 1}, {a: 2}, {a: 3}][a >= 2]", new Variable (new List<Variable> () { new ContextInputs ().Add ("a", 2), new ContextInputs ().Add ("a", 3) }) },
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}