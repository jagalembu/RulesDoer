using System;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Eval {
    public class AstVisitor : IAstVisitor {
        private readonly VariableContext _variableContext;

        public AstVisitor (VariableContext variableContext) {
            _variableContext = variableContext;
        }

        public object Visit (IEle element) {
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

        public IEle VisitManyExpressions (ManyExpressions ele) {
            //TODO: loop thru and return string of expression results
            return null;
        }

        public Variable VisitAddition (Addition ele) {
            var leftVal = Visit (ele.Left);
            var rightVal = Visit (ele.Right);

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return l.NumericVal + r.NumericVal;

                    default:
                        throw new FEELException ("Failed to perform addition to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform addition due to values not being a variable");

        }
        public Variable VisitDivision (Division ele) {
            var leftVal = Visit (ele.Left);
            var rightVal = Visit (ele.Right);

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return l.NumericVal + r.NumericVal;

                    default:
                        throw new FEELException ("Failed to perform addition to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform addition due to values not being a variable");
        }
        public Variable VisitMultiplication (Multiplication ele) {
            var leftVal = Visit (ele.Left);
            var rightVal = Visit (ele.Right);

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return l.NumericVal * r.NumericVal;

                    default:
                        throw new FEELException ("Failed to perform addition to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform addition due to values not being a variable");
        }
        public Variable VisitSubtraction (Subtraction ele) {
            var leftVal = Visit (ele.Left);
            var rightVal = Visit (ele.Right);

            if (leftVal is Variable l && rightVal is Variable r) {
                switch (l.ValueType) {
                    case DataTypeEnum.Decimal:
                        return l.NumericVal - r.NumericVal;

                    default:
                        throw new FEELException ("Failed to perform addition to incorrect FEEL type");
                }
            }

            throw new FEELException ("Failed to perform addition due to values not being a variable");

        }
        public Variable VisitNullLiteral (NullLiteral ele) {
            return new Variable ();
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
            return new Variable (true);
            // return ele.Execute(this) as Variable;
        }

    }
}