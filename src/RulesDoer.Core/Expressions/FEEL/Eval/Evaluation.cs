using System.IO;
using Antlr4.Runtime;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class Evaluation {
        private readonly VariableContext _context;
        private readonly IAstVisitor _astVisitor;

        public Evaluation (VariableContext context, IAstVisitor astVisitor) {
            _context = context;
            _astVisitor = astVisitor;
        }

        // public IEle ParseUnaryTests (string exprText) {
        //     var parser = RetrieveParser (exprText);
        //     var cst = parser.unaryTestsRoot ();
        //     var ast = new BuildAstVisitor ().VisitUnaryTestsRoot (cst);
        //     return ast;
        // }
        // public IEle ParseSimpleUnaryTests (string exprText) {
        //     var parser = RetrieveParser (exprText);
        //     var cst = parser.simpleUnaryTests ();
        //     var ast = new BuildAstVisitor ().VisitSimpleUnaryTests (cst);
        //     return ast;
        // }

        public IEle ParseExpression (string exprText) {
            var parser = RetrieveParser (exprText);
            var cst = parser.expression ();
            var ast = new BuildAst ().VisitExpression (cst);
            return ast;
        }

        public IEle ParseSimpleExpressions (string exprText) {
            var parser = RetrieveParser (exprText);
            var cst = parser.simpleExpressions ();
            var ast = new BuildAst ().VisitSimpleExpressions (cst);
            return ast;
        }

        // public IEle ParseTextualExpressions (string exprText) {
        //     var parser = RetrieveParser (exprText);
        //     var cst = parser.textualExpressionsRoot ();
        //     var ast = new BuildAstVisitor ().VisitTextualExpressionsRoot (cst);
        //     return ast;
        // }
        // public IEle ParseBoxedExpression (string exprText) {
        //     var parser = RetrieveParser (exprText);
        //     var cst = parser.boxedExpressionRoot ();
        //     var ast = new BuildAstVisitor ().VisitBoxedExpressionRoot (cst);
        //     return ast;
        // }

        public Variable EvaluateExpression (string exprText) {
            var ast = ParseExpression (exprText);
            var variable = _astVisitor.Visit (ast);
            return variable;
        }

        private FEELGrammar RetrieveParser (string exprText) {
            var inputStream = new AntlrInputStream (new StringReader (exprText));
            var lexer = new FEELLexer (inputStream);
            var tokenStream = new CommonTokenStream (lexer);
            return new FEELGrammar (tokenStream);
        }
    }
}