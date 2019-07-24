using System;

namespace RulesDoer.Core {
    public class DMNException : Exception {
        public DMNException () { }
        public DMNException (string message) : base (message) { }
        public DMNException (string message, System.Exception inner) : base (message, inner) { }
    }
}