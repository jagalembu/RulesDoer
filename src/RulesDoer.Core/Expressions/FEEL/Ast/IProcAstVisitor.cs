using RulesDoer.Core.Expressions.FEEL.Ast.Elements;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths;

namespace RulesDoer.Core.Expressions.FEEL.Ast {
    public interface IProcAstVisitor {

        // //
        // // Tests
        // //
        // Object Visit (PositiveUnaryTests element, FEELContext params);

        // Object Visit (NegatedPositiveUnaryTests element, FEELContext params);

        // Object Visit (SimplePositiveUnaryTests element, FEELContext params);

        // Object Visit (NegatedSimplePositiveUnaryTests element, FEELContext params);

        // Object Visit (Any element, FEELContext params);

        // Object Visit (NullTest element, FEELContext params);

        // Object Visit (ExpressionTest element, FEELContext params);

        // Object Visit (OperatorTest element, FEELContext params);

        // Object Visit (RangeTest element, FEELContext params);

        // Object Visit (ListTest element, FEELContext params);

        // //
        // // Textual expressions
        // //
        // Object Visit (FormalParameter element, FEELContext params);

        // Object Visit (FunctionDefinition element, FEELContext params);

        // Object Visit (Context element, FEELContext params);

        // Object Visit (ContextEntry element, FEELContext params);

        // Object Visit (ContextEntryKey element, FEELContext params);

        // Object Visit (ForExpression element, FEELContext params);

        // Object Visit (Iterator element, FEELContext params);

        // Object Visit (ExpressionIteratorDomain element, FEELContext params);

        // Object Visit (RangeIteratorDomain element, FEELContext params);

        // Object Visit (IfExpression element, FEELContext params);

        // Object Visit (QuantifiedExpression element, FEELContext params);

        // Object Visit (FilterExpression element, FEELContext params);

        // Object Visit (InstanceOfExpression element, FEELContext params);

        // //
        // // Expressions
        // //
        object Visit (ManyExpressions ele);

        // //
        // // Logic expressions
        // //
        // Object Visit (Disjunction element, FEELContext params);

        // Object Visit (Conjunction element, FEELContext params);

        // Object Visit (LogicNegation element, FEELContext params);

        // //
        // // Comparison expressions
        // //
        // Object Visit (Relational element, FEELContext params);

        // Object Visit (BetweenExpression element, FEELContext params);

        // Object Visit (InExpression element, FEELContext params);

        // //
        // // Math expressions
        // //
        object Visit (Addition ele);
        object Visit (Subtraction ele);
        object Visit (Division ele);
        object Visit (Multiplication ele);

        // //
        // // Postfix expressions
        // //
        // Object Visit (FunctionInvocation element, FEELContext params);

        // Object Visit (NamedParameters element, FEELContext params);

        // Object Visit (PositionalParameters element, FEELContext params);

        // Object Visit (PathExpression element, FEELContext params);

        // //
        // // Literal expressions
        // //
        object Visit (BooleanLiteral ele);
        object Visit (DateTimeLiteral ele);

        object Visit (NullLiteral ele);
        object Visit (NumericLiteral ele);
        object Visit (StringLiteral ele);

        // Object Visit (DateTimeLiteral element, FEELContext params);

        // Object Visit (NullLiteral element, FEELContext params);

        // Object Visit (NumericLiteral element, FEELContext params);

        // Object Visit (StringLiteral element, FEELContext params);

        // Object Visit (ListLiteral element, FEELContext params);

        // Object Visit (QualifiedName element, FEELContext params);

        // Object Visit (Name element, FEELContext params);
    }
}