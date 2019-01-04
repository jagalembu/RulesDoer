using System;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Math;
using RulesDoer.Core.Runtime.Context;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class AstVisitor : IAstVisitor {
        private readonly VariableContext _variableContext;

        public AstVisitor (VariableContext variableContext) {
            _variableContext = variableContext;
        }

        public Variable Visit (IEle element) {
            switch (element) {
                case Addition e:
                    return VisitAddition (e);
                case Subtraction e:
                    return VisitSubtraction (e);
                case Multiplication e:
                    return VisitMultiplication (e);
                case Division e:
                    return VisitDivision (e);
                case BooleanLiteral e:
                    return VisitBooleanLiteral (e);
                case StringLiteral e:
                    return VisitStringLiteral (e);
                case NumericLiteral e:
                    return VisitNumericLiteral (e);
                case NullLiteral e:
                    return VisitNullLiteral (e);
                case ManyExpressions e:
                    return VisitManyExpressions (e);
                default:
                    throw new Exception ("Wrong visitation path.");
            }
        }

        public Variable VisitManyExpressions(ManyExpressions ele)
        {
            //TODO: loop thru and return string of expression results
            return new Variable();
        }
        public Variable VisitAddition (Addition ele) {
            return new Variable (Visit (ele.Left).NumericVal + Visit (ele.Right).NumericVal);
        }
        public Variable VisitDivision (Division ele) {
            return new Variable (Visit (ele.Left).NumericVal / Visit (ele.Right).NumericVal);
        }
        public Variable VisitMultiplication (Multiplication ele) {
            return new Variable (Visit (ele.Left).NumericVal * Visit (ele.Right).NumericVal);
        }
        public Variable VisitSubtraction (Subtraction ele) {
            return new Variable (Visit (ele.Left).NumericVal - Visit (ele.Right).NumericVal);

        }
        public Variable VisitNullLiteral (NullLiteral ele) {
            return new Variable();
        }

        public Variable VisitNumericLiteral (NumericLiteral ele) {
            return ele.Value;
        }

        public Variable VisitStringLiteral (StringLiteral ele) {
            return ele.Value;
        }

        public Variable VisitBooleanLiteral (BooleanLiteral ele) {
            return ele.Value;
        }

        public Variable VisitDateTimeLiteral (DateTimeLiteral ele) {
            return ele.Value;
        }

    }
}