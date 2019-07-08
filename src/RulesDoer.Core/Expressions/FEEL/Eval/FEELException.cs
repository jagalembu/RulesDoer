using System;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class FEELException : Exception {
        public FEELException () { }
        public FEELException (string message) : base (message) { }
        public FEELException (string message, System.Exception inner) : base (message, inner) { }
    }

}