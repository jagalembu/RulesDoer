using System.Collections.Generic;
using System.IO;
using Antlr4.Runtime;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class ParserErrors : BaseErrorListener {
        public List<string> ErrorList { get; set; } = new List<string> ();
        public override void SyntaxError (TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e) {
            ErrorList.Add (msg);
        }
    }
}