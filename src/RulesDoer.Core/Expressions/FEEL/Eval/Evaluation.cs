using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class Evaluation {
        private readonly VariableContext _context;
        private readonly IProcAstVisitor _astVisitor;

        public Evaluation (VariableContext context) {
            _context = context;
        }

        public Variable EvaluateSimpleExpressionsBase (string expressionText) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.simpleExpressionsBase ();

            var listerner = new SimpleExpressionsBaseAst ();
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public Variable EvaluateExpressionsBase (string expressionText) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.expressionBase ();

            var listerner = new ExpressionBaseAst ();
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        private FEELRule RetrieveParser (string exprText) {
            var inputStream = new AntlrInputStream (new StringReader (exprText));
            var lexer = new FEELLexer (inputStream);
            var tokenStream = new CommonTokenStream (lexer);
            var parser = new FEELRule (tokenStream);
            parser.BuildParseTree = true;
            return parser;
        }

    }
}