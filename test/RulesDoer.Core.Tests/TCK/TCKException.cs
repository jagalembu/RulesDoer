using System;

namespace RulesDoer.Core.Tests.TCK {
    public class TCKException : Exception {
        public TCKException () { }
        public TCKException (string message) : base (message) { }
        public TCKException (string message, System.Exception inner) : base (message, inner) { }
    }
}