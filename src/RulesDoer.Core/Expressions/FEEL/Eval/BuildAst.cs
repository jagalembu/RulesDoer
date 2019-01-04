using System;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Logic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class BuildAst : FEELGrammarBaseVisitor<IEle> {

        #region Main Rules

        public override IEle VisitExpression (FEELGrammar.ExpressionContext context) {
            return Visit (context.textualExpression ());
        }
        public override IEle VisitSimpleExpressions (FEELGrammar.SimpleExpressionsContext context) {
            var expressions = new ManyExpressions ();
            foreach (var item in context.simpleExpression ()) {
                var ele = Visit (item);
                expressions.ExpressionLists.Add ((IExpression) ele);
            }

            return expressions;
        }
        #endregion Main Rules

        #region Expression

        #endregion Expression

        #region TextualExpressions
        public override IEle VisitForExpr (FEELGrammar.ForExprContext context) {
            return VisitForExpression (context.forExpression ());
        }

        public override IEle VisitIfExpr (FEELGrammar.IfExprContext context) {
            return VisitIfExpression (context.ifExpression ());
        }

        public override IEle VisitQuantifiedExpr (FEELGrammar.QuantifiedExprContext context) {
            return VisitQuantifiedExpression (context.quantifiedExpression ());
        }

        public override IEle VisitDisjunctionExpr (FEELGrammar.DisjunctionExprContext context) {
            return VisitDisjunction (context.disjunction ());
        }

        // public override IEle VisitConjunctionExpr (FEELGrammar.ConjunctionExprContext context) {
        //     return VisitConjunction (context.conjunction ());
        // }

        // public override IEle VisitComparisonExpr (FEELGrammar.ComparisonExprContext context) {
        //     return VisitComparison (context.comparison ());
        // }

        // public override IEle VisitArithmeticTxtExpr (FEELGrammar.ArithmeticTxtExprContext context) {
        //     return Visit (context.arithmeticExpression ());
        // }

        // public override IEle VisitLiteralExpr (FEELGrammar.LiteralExprContext context) {
        //     return Visit (context.literal ());
        // }
        #endregion TextualExpressions

        #region Logic

        public override IEle VisitForExpression (FEELGrammar.ForExpressionContext context) {
            throw new NotImplementedException ();
        }

        public override IEle VisitIfExpression (FEELGrammar.IfExpressionContext context) {
            throw new NotImplementedException ();
        }

        public override IEle VisitQuantifiedExpression (FEELGrammar.QuantifiedExpressionContext context) {
            throw new NotImplementedException ();
        }

        public override IEle VisitDisjunction (FEELGrammar.DisjunctionContext context) {
            var leftEle = VisitConjunction (context.left);
            if (context.right != null) {
                return new Disjunction ((IExpression) leftEle, (IExpression) VisitConjunction (context.right));
            }

            return leftEle;
        }

        public override IEle VisitConjunction (FEELGrammar.ConjunctionContext context) {
            var leftEle = VisitComparison (context.left);
            if (context.right != null) {
                return new Conjuction ((IExpression) leftEle, (IExpression) VisitComparison (context.right));
            }

            return leftEle;
        }

        public override IEle VisitComparison (FEELGrammar.ComparisonContext context) {
            IEle firstEle;
            if (context.firstAst != null) {
                firstEle = VisitArithmeticExpression (context.firstAst);
                if (context.op != null) {
                    return new Relational (context.op.Text, (IExpression) firstEle, (IExpression) Visit (context.secondAst));
                } else if (context.left != null) {
                    return new Between ((IExpression) firstEle, (IExpression) Visit (context.left), (IExpression) Visit (context.right));
                }
                return firstEle;
            }
            return null;
        }
        // public override IEle VisitRelationalExpr (FEELGrammar.RelationalExprContext context) {
        //     return new Relational (context.op.Text, (IExpression) Visit (context.left), (IExpression) Visit (context.right));
        // }

        // public override IEle VisitBetweenExpr (FEELGrammar.BetweenExprContext context) {
        //     return new Between ((IExpression) Visit (context.input), (IExpression) Visit (context.left), (IExpression) Visit (context.right));
        // }

        #endregion Logic

        #region Math

        public override IEle VisitArithmeticExpr (FEELGrammar.ArithmeticExprContext context) {
            return VisitArithmeticExpression (context.arithmeticExpression ());
        }
        public override IEle VisitArithmeticExpression (FEELGrammar.ArithmeticExpressionContext context) {
            return VisitAddition (context.addition ());
        }
        public override IEle VisitAddition (FEELGrammar.AdditionContext context) {
            if (context.right != null) {
                var addition = new Addition ();

                addition.Left = (IExpression) VisitSubtraction (context.left);
                addition.Right = (IExpression) VisitSubtraction (context.right);

                return addition;
            }

            return VisitSubtraction (context.left);
        }

        public override IEle VisitSubtraction (FEELGrammar.SubtractionContext context) {
            if (context.right != null) {
                var subtraction = new Subtraction ();

                subtraction.Left = (IExpression) VisitMultiplication (context.left);
                subtraction.Right = (IExpression) VisitMultiplication (context.right);

                return subtraction;
            }

            return VisitMultiplication (context.left);
        }

        public override IEle VisitMultiplication (FEELGrammar.MultiplicationContext context) {
            if (context.right != null) {
                var multiplication = new Multiplication ();

                multiplication.Left = (IExpression) VisitDivision (context.left);
                multiplication.Right = (IExpression) VisitDivision (context.right);

                return multiplication;
            }

            return VisitDivision (context.left);

        }

        public override IEle VisitDivision (FEELGrammar.DivisionContext context) {
            if (context.right != null) {
                var division = new Division ();

                division.Left = (IExpression) VisitExponentiation (context.left);
                division.Right = (IExpression) VisitExponentiation (context.right);

                return division;
            }

            return VisitExponentiation (context.left);

        }

        public override IEle VisitExponentiation (FEELGrammar.ExponentiationContext context) {

            if (context.right != null) {

                var exponentiation = new Exponentiation ();

                exponentiation.Left = (IExpression) VisitArithmeticNegation (context.left);
                exponentiation.Right = (IExpression) VisitArithmeticNegation (context.right);

                return exponentiation;
            }

            return VisitArithmeticNegation (context.left);

        }

        public override IEle VisitArithmeticNegation (FEELGrammar.ArithmeticNegationContext context) {
            if (context.Start.Text == "-") {
                var negation = new ArithmeticNegation ();
                negation.Right = (IExpression) Visit (context.expr);
                return negation;
            }
            return Visit (context.expr);
        }

        #endregion Math

        #region Literals
        public override IEle VisitSimpleLitExpr (FEELGrammar.SimpleLitExprContext context) => Visit (context.simpleLiteral ());

        public override IEle VisitSimpleLiteralExpr (FEELGrammar.SimpleLiteralExprContext context) {
            return Visit (context.simpleLiteral ());
        }

        public override IEle VisitStringLiteralExpr (FEELGrammar.StringLiteralExprContext context) {
            return VisitStringLiteral (context.stringLiteral ());
        }

        public override IEle VisitNumericLiteralExpr (FEELGrammar.NumericLiteralExprContext context) {
            return VisitNumericLiteral (context.numericLiteral ());
        }

        public override IEle VisitBooleanLiteralExpr (FEELGrammar.BooleanLiteralExprContext context) {
            return VisitBooleanLiteral (context.booleanLiteral ());
        }

        public override IEle VisitDateTimeLiteralExpr (FEELGrammar.DateTimeLiteralExprContext context) {
            return VisitDateTimeLiteral (context.dateTimeLiteral ());
        }

        public override IEle VisitStringLiteral (FEELGrammar.StringLiteralContext context) {
            return new StringLiteral (context.lit.Text);
        }

        public override IEle VisitNumericLiteral (FEELGrammar.NumericLiteralContext context) {
            return new NumericLiteral (context.lit.Text);
        }
        public override IEle VisitBooleanLiteral (FEELGrammar.BooleanLiteralContext context) {
            return new BooleanLiteral (context.lit.Text);
        }

        public override IEle VisitDateTimeLiteral (FEELGrammar.DateTimeLiteralContext context) {
            return null;
            //return new DateTimeLiteral(context)
        }

        public override IEle VisitIdentifier (FEELGrammar.IdentifierContext context) {
            return new StringLiteral (context.token.Text);
        }

        public override IEle VisitIntervalStartPar (FEELGrammar.IntervalStartParContext context) {
            return new StringLiteral (context.token.Text);
        }

        public override IEle VisitIntervalEndPar (FEELGrammar.IntervalEndParContext context) {
            return new StringLiteral (context.token.Text);
        }
        #endregion  Literals
    }
}