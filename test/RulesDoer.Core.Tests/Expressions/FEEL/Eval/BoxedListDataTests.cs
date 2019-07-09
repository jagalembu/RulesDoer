using System.Collections;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval
{
    public class BoxedListDataTests: IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "[1,2,3]", new Variable(new List<Variable>(){ 1, 2, 3}), true },
            new object[] { "[1,2+3,3]", new Variable(new List<Variable>(){ 1, 5, 3}), true },
            new object[] { "[1,2,3]", new Variable(new List<Variable>(){ 1, 2, 4}), false },
            new object[] { "[1,2,3]", new Variable(new List<Variable>(){ 3, 2, 1}), false },
            new object[] { "[1,true,\"3\"]", new Variable(new List<Variable>(){ 1, true, "3"}), true }
        };

        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}