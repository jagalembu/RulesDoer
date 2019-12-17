using System.Collections;
using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Tests.Expressions.FEEL.Eval {
    public class ForDataTests : IEnumerable<object[]> {
        private readonly List<object[]> _data = new List<object[]> {
            new object[] { "for i in 3..-2 return i", new Variable (new List<Variable> () { 3, 2, 1, 0, -1, -2 }) },
            new object[] { "for i in 4..2 return i", new Variable (new List<Variable> () { 4, 3, 2 }) },
            new object[] { "for i in [1..3] return i", new Variable (new List<Variable> () { 1, 2, 3 }) },
            new object[] { "for i in [1,2,3] return i", new Variable (new List<Variable> () { 1, 2, 3 }) },
            new object[] { "for i in [1,2] return for x in 5..6 return i+x", new Variable (new List<Variable> () { new List<Variable> () { 6, 7 }, new List<Variable> () { 7, 8 } }) },
            new object[] { "for i in [1,2], x in 5..6 return i+x", new Variable (new List<Variable> () { 6, 7, 7, 8 }) },
            new object[] { "for i in [1,2,3], j in [4,5] return i + j", new Variable (new List<Variable> () { 5, 6, 6, 7, 7, 8 }) },
            new object[] { "for i in 0..4 return if i = 0 then 1 else i * partial[-1]", new Variable (new List<Variable> () { 1, 1, 2, 6, 24 })}
        };
        public IEnumerator<object[]> GetEnumerator () => _data.GetEnumerator ();

        IEnumerator IEnumerable.GetEnumerator () => GetEnumerator ();
    }
}