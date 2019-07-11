//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from FEELRule.g4 by ANTLR 4.7.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace RulesDoer.Core.Expressions.FEEL {

using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Expressions.FEEL.Ast;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Comparison;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Logic;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Maths;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Match;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Boxed;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements;

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="FEELRule"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7.2")]
[System.CLSCompliant(false)]
public interface IFEELRuleListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleExpressionsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleExpressionsBase([NotNull] FEELRule.SimpleExpressionsBaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleExpressionsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleExpressionsBase([NotNull] FEELRule.SimpleExpressionsBaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.expressionBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpressionBase([NotNull] FEELRule.ExpressionBaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.expressionBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpressionBase([NotNull] FEELRule.ExpressionBaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.unaryTestsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryTestsBase([NotNull] FEELRule.UnaryTestsBaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.unaryTestsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryTestsBase([NotNull] FEELRule.UnaryTestsBaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleUnaryTestsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleUnaryTestsBase([NotNull] FEELRule.SimpleUnaryTestsBaseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleUnaryTestsBase"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleUnaryTestsBase([NotNull] FEELRule.SimpleUnaryTestsBaseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpression([NotNull] FEELRule.ExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpression([NotNull] FEELRule.ExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleUnaryTests([NotNull] FEELRule.SimpleUnaryTestsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleUnaryTests([NotNull] FEELRule.SimpleUnaryTestsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simplePositiveUnaryTest"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimplePositiveUnaryTest([NotNull] FEELRule.SimplePositiveUnaryTestContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simplePositiveUnaryTest"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimplePositiveUnaryTest([NotNull] FEELRule.SimplePositiveUnaryTestContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.interval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterInterval([NotNull] FEELRule.IntervalContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.interval"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitInterval([NotNull] FEELRule.IntervalContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simplePositiveUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimplePositiveUnaryTests([NotNull] FEELRule.SimplePositiveUnaryTestsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simplePositiveUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimplePositiveUnaryTests([NotNull] FEELRule.SimplePositiveUnaryTestsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.positiveUnaryTest"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPositiveUnaryTest([NotNull] FEELRule.PositiveUnaryTestContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.positiveUnaryTest"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPositiveUnaryTest([NotNull] FEELRule.PositiveUnaryTestContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.positiveUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPositiveUnaryTests([NotNull] FEELRule.PositiveUnaryTestsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.positiveUnaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPositiveUnaryTests([NotNull] FEELRule.PositiveUnaryTestsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.unaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterUnaryTests([NotNull] FEELRule.UnaryTestsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.unaryTests"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitUnaryTests([NotNull] FEELRule.UnaryTestsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.boxedExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBoxedExpression([NotNull] FEELRule.BoxedExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.boxedExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBoxedExpression([NotNull] FEELRule.BoxedExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterList([NotNull] FEELRule.ListContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitList([NotNull] FEELRule.ListContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.context"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContext([NotNull] FEELRule.ContextContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.context"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContext([NotNull] FEELRule.ContextContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.contextEntry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterContextEntry([NotNull] FEELRule.ContextEntryContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.contextEntry"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitContextEntry([NotNull] FEELRule.ContextEntryContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.textualExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTextualExpression([NotNull] FEELRule.TextualExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.textualExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTextualExpression([NotNull] FEELRule.TextualExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleExpressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleExpressions([NotNull] FEELRule.SimpleExpressionsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleExpressions"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleExpressions([NotNull] FEELRule.SimpleExpressionsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleExpression([NotNull] FEELRule.SimpleExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleExpression([NotNull] FEELRule.SimpleExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterArithmeticExpression([NotNull] FEELRule.ArithmeticExpressionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.arithmeticExpression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitArithmeticExpression([NotNull] FEELRule.ArithmeticExpressionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameters([NotNull] FEELRule.ParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.parameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameters([NotNull] FEELRule.ParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.namedParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNamedParameters([NotNull] FEELRule.NamedParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.namedParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNamedParameters([NotNull] FEELRule.NamedParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.positionalParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterPositionalParameters([NotNull] FEELRule.PositionalParametersContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.positionalParameters"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitPositionalParameters([NotNull] FEELRule.PositionalParametersContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.endpoint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterEndpoint([NotNull] FEELRule.EndpointContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.endpoint"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitEndpoint([NotNull] FEELRule.EndpointContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleValue([NotNull] FEELRule.SimpleValueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleValue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleValue([NotNull] FEELRule.SimpleValueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.typeIs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTypeIs([NotNull] FEELRule.TypeIsContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.typeIs"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTypeIs([NotNull] FEELRule.TypeIsContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterQualifiedName([NotNull] FEELRule.QualifiedNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.qualifiedName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitQualifiedName([NotNull] FEELRule.QualifiedNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLiteral([NotNull] FEELRule.LiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLiteral([NotNull] FEELRule.LiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.simpleLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSimpleLiteral([NotNull] FEELRule.SimpleLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.simpleLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSimpleLiteral([NotNull] FEELRule.SimpleLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.dateTimeLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDateTimeLiteral([NotNull] FEELRule.DateTimeLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.dateTimeLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDateTimeLiteral([NotNull] FEELRule.DateTimeLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIdentifier([NotNull] FEELRule.IdentifierContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.identifier"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIdentifier([NotNull] FEELRule.IdentifierContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterStringLiteral([NotNull] FEELRule.StringLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitStringLiteral([NotNull] FEELRule.StringLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBooleanLiteral([NotNull] FEELRule.BooleanLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.booleanLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBooleanLiteral([NotNull] FEELRule.BooleanLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.numericLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNumericLiteral([NotNull] FEELRule.NumericLiteralContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.numericLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNumericLiteral([NotNull] FEELRule.NumericLiteralContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.intervalStartPar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntervalStartPar([NotNull] FEELRule.IntervalStartParContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.intervalStartPar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntervalStartPar([NotNull] FEELRule.IntervalStartParContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.intervalEndPar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIntervalEndPar([NotNull] FEELRule.IntervalEndParContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.intervalEndPar"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIntervalEndPar([NotNull] FEELRule.IntervalEndParContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.parameterName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParameterName([NotNull] FEELRule.ParameterNameContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.parameterName"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParameterName([NotNull] FEELRule.ParameterNameContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="FEELRule.key"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterKey([NotNull] FEELRule.KeyContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="FEELRule.key"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitKey([NotNull] FEELRule.KeyContext context);
}
} // namespace RulesDoer.Core.Expressions.FEEL
