using System.IO;
using System.Linq;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class Evaluation {

        public bool EvaluateSimpleUnaryTestsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.simpleUnaryTestsBase ();

            ThrowParserErrors (expressionText, "SimpleUnaryTestsBase", parser);

            var listerner = new SimpleUnaryTestsBaseAst (context, inputName);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public bool EvaluateUnaryTestsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.unaryTestsBase ();

            ThrowParserErrors (expressionText, "UnaryTestsBase", parser);

            var listerner = new UnaryTestsBaseAst (context, inputName);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public Variable EvaluateSimpleExpressionsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.simpleExpressionsBase ();
            ThrowParserErrors (expressionText, "SimpleExpressionsBase", parser);

            var listerner = new SimpleExpressionsBaseAst (context);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public Variable EvaluateExpressionsBase (string expressionText, VariableContext context) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.expressionBase ();
            ThrowParserErrors (expressionText, "ExpressionBase", parser);

            var listerner = new ExpressionBaseAst (context);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        private FEELRule RetrieveParser (string exprText) {
            var inputStream = CharStreams.fromstring(exprText);
            //var inputStream = new AntlrInputStream (new StringReader (exprText));
            var lexer = new FEELLexer (inputStream);
            lexer.RemoveErrorListeners ();
            lexer.AddErrorListener (new LexerErrors ());
            var tokenStream = new CommonTokenStream (lexer);
            var parser = new FEELRule (tokenStream);
            parser.RemoveErrorListeners ();
            parser.AddErrorListener (new ParserErrors ());
            parser.BuildParseTree = true;
            return parser;
        }

        private void ThrowParserErrors (string exprTxt, string whichFeel, FEELRule parser) {
            var parserErrs = parser.ErrorListeners[0] as ParserErrors;

            if (parserErrs.ErrorList.Any()) {
                var errTxt = "";

                foreach (var item in parserErrs.ErrorList) {
                    errTxt += item;
                }

                throw new FEELException ($"Problem parsing the input expresion: {exprTxt} : {whichFeel} : {errTxt}");
            }
        }

    }
}