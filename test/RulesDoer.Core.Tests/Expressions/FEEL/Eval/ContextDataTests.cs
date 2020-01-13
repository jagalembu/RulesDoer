using System.Collections;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class ContextDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "{\"a\":1}", new Variable (new ContextInputs ().Add ("a", 1)), true },
            new object[] { "{a:1}", new Variable (new ContextInputs ().Add ("a", 1)), true },
            new object[] { "{a:1, b:{ x: 4}}", new Variable (new ContextInputs ().Add ("a", 1).Add ("b", new ContextInputs ().Add ("x", 4))), true },
            new object[] { "{a: 1 + 2, b: a + 3}", new Variable(new ContextInputs().Add("a", 3).Add("b", 6)), true},
            new object[] { "{a: 1 + 2, b: 3, c: {d: a + b}}", new Variable(new ContextInputs().Add("a", 3).Add("b", 3).Add("c", new ContextInputs().Add("d",6))), true},
            new object[] { "{a b: 1 + 2}", new Variable(new ContextInputs().Add("a b", 3)), true}            
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}