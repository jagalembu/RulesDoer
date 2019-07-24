using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class Evaluation {
        // private readonly VariableContext _context;
        // private readonly string _inputName;

        // public Evaluation (VariableContext context) {
        //     _context = context;
        // }

        // public Evaluation (VariableContext context, string inputName) : this (context) {
        //     _inputName = inputName;
        // }

        public bool EvaluateSimpleUnaryTestsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.simpleUnaryTestsBase ();

            var listerner = new SimpleUnaryTestsBaseAst (context, inputName);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public bool EvaluateUnaryTestsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.unaryTestsBase ();

            var listerner = new UnaryTestsBaseAst (context, inputName);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public Variable EvaluateSimpleExpressionsBase (string expressionText, VariableContext context, string inputName = null) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.simpleExpressionsBase ();

            var listerner = new SimpleExpressionsBaseAst (context);
            ParseTreeWalker.Default.Walk (listerner, tree);

            return listerner.Value;
        }

        public Variable EvaluateExpressionsBase (string expressionText, VariableContext context) {
            var parser = RetrieveParser (expressionText);
            var tree = parser.expressionBase ();

            var listerner = new ExpressionBaseAst (context);
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