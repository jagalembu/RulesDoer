using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class LexerErrors : IAntlrErrorListener<int> {
        public List<string> ErrorList { get; set; } = new List<string> ();

        public void SyntaxError (TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            ErrorList.Add (msg);
        }
    }
}