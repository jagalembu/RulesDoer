parser grammar FEELRule;

options {
	tokenVocab = FEELLexer;
}

@header {
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
}

@parser::members {


}

//base rule

simpleExpressionsBase
	returns[IExpression ast]:
	simpleExpressions {$ast = $simpleExpressions.ast;} EOF;

expressionBase
	returns[IExpression ast]:
	expression {$ast = $expression.ast;} EOF;

unaryTestsBase
	returns[ITestExpression ast]:
	unaryTests {$ast = $unaryTests.ast;} EOF;

simpleUnaryTestsBase
	returns[ITestExpression ast]:
	simpleUnaryTests {$ast = $simpleUnaryTests.ast;} EOF;

//expression
expression
	returns[IExpression ast]:
	boxedExpression {$ast = $boxedExpression.ast;}
	| textualExpression {$ast = $textualExpression.ast;};

//tests
simpleUnaryTests
	returns[ITestExpression ast]:
	simplePositiveUnaryTests {$ast =  $simplePositiveUnaryTests.ast;}
	| NOT PAREN_OPEN simplePositiveUnaryTests PAREN_CLOSE {$ast = new NotTest($simplePositiveUnaryTests.ast);
		}
	| MINUS {$ast = new AnyTest();};

simplePositiveUnaryTest
	returns[ITestExpression ast]:
	(
		{var opEnum = OperatorEnum.NF;} (
			op = LT { opEnum = OperatorEnum.LT;}
			| op = GT { opEnum = OperatorEnum.GT;}
			| op = LE { opEnum = OperatorEnum.LE;}
			| op = GE { opEnum = OperatorEnum.GE;}
		)? endpoint {$ast = new OperatorTest(opEnum, $endpoint.ast);}
	)
	| interval {$ast = $interval.ast;};

interval
	returns[ITestExpression ast]:
	startNotation = intervalStartPar leftVal = endpoint DOT_DOT rightVal = endpoint endNotation =
		intervalEndPar {$ast = new IntervalTest($startNotation.text, $endNotation.text, $leftVal.ast, $rightVal.ast);
		};

simplePositiveUnaryTests
	returns[ITestExpression ast]:
	{List<ITestExpression> expressions = new List<ITestExpression>();} st = simplePositiveUnaryTest
		{expressions.Add($st.ast);
		} (
		COMMA st = simplePositiveUnaryTest {expressions.Add($st.ast);}
	)* {$ast = new SimplePositiveUnaryTests(expressions);};

positiveUnaryTest
	returns[ITestExpression ast]:
	expression {$ast = new PositiveUnaryTest($expression.ast);};

positiveUnaryTests
	returns[ITestExpression ast]:
	{List<ITestExpression> expressions = new List<ITestExpression>();} pt = positiveUnaryTest {expressions.Add($pt.ast);
		} (COMMA pt = positiveUnaryTest {expressions.Add($pt.ast);})* {$ast = new PositiveUnaryTests(expressions);
		};

unaryTests
	returns[ITestExpression ast]:
	positiveUnaryTests {$ast = $positiveUnaryTests.ast;}
	| NOT PAREN_OPEN positiveUnaryTests PAREN_CLOSE {$ast = new NotTest($positiveUnaryTests.ast);}
	| MINUS {$ast = new AnyTest();};

//boxed expression
boxedExpression
	returns[IExpression ast]:
	list {$ast = $list.ast;}
	| context {$ast = $context.ast;};

list
	returns[IExpression ast]:
	{List<IExpression> expressions = new List<IExpression>();} BRACKET_OPEN (
		exp = expression {expressions.Add($exp.ast);} (
			COMMA exp = expression {expressions.Add($exp.ast);}
		)*
	) BRACKET_CLOSE {$ast = new ListLiteral(expressions);};

context
	returns[IExpression ast]:
	{List<IExpression> cnEntries = new List<IExpression>();} BRACE_OPEN (
		contextEntry {cnEntries.Add($contextEntry.ast);} (
			COMMA contextEntry {cnEntries.Add($contextEntry.ast);}
		)*
	)? BRACE_CLOSE {$ast = new ContextBoxed(cnEntries);};

contextEntry
	returns[IExpression ast]:
	key COLON expression {$ast = new ContextEntryBoxed($key.text, $expression.ast);};

//textual expression
textualExpression
	returns[IExpression ast]:
	| left = textualExpression OR right = textualExpression {$ast = new Disjunction($left.ast, $right.ast);
		}
	| left = textualExpression AND right = textualExpression {$ast = new Conjuction($left.ast, $right.ast);
		}
	| comparison {$ast = $comparison.ast;}
	//	| arithmeticExpression {$ast = $arithmeticExpression.ast;}
	| PAREN_OPEN textualExpression {$ast = $textualExpression.ast;} PAREN_CLOSE;

//simple expression
simpleExpressions
	returns[IExpression ast]:
	{List<IExpression> exprList = new List<IExpression>();} simpleExpression {exprList.Add($simpleExpression.ast);
		} (COMMA exp = simpleExpression {exprList.Add($exp.ast);})* {$ast = new ManyExpressions(exprList);
		};

simpleExpression
	returns[IExpression ast]: (
		arithmeticExpression {$ast = $arithmeticExpression.ast;}
	)
	| (simpleValue {$ast = $simpleValue.ast; });

// Comparison
comparison
	returns[IExpression ast]:
	as1 = comparison {var opEnum = OperatorEnum.NF;} (
		op = EQ { opEnum = OperatorEnum.EQ;}
		| op = NE { opEnum = OperatorEnum.NE;}
		| op = LT { opEnum = OperatorEnum.LT;}
		| op = GT { opEnum = OperatorEnum.GT;}
		| op = LE { opEnum = OperatorEnum.LE;}
		| op = GE { opEnum = OperatorEnum.GE;}
	) as2 = comparison {$ast = new Relational(opEnum, $as1.ast, $as2.ast);}
	| arithmeticExpression {$ast = $arithmeticExpression.ast;};

//arithmetic expression
arithmeticExpression
	returns[IExpression ast]:
	left = arithmeticExpression PLUS right = arithmeticExpression {$ast = new Addition($left.ast, $right.ast);
			}
	| left = arithmeticExpression MINUS right = arithmeticExpression {$ast = new Subtraction($left.ast, $right.ast);
			}
	| left = arithmeticExpression STAR right = arithmeticExpression {$ast = new Multiplication($left.ast, $right.ast);
			}
	| left = arithmeticExpression FORWARD_SLASH right = arithmeticExpression {$ast = new Division($left.ast, $right.ast);
			}
	| left = arithmeticExpression STAR_STAR right = arithmeticExpression {$ast = new Exponentiation($left.ast, $right.ast);
			}
	| (MINUS)+ expr = arithmeticExpression {$ast = new ArithmeticNegation($expr.ast);}
	| expr = arithmeticExpression INSTANCE_OF typeIs {$ast = new InstanceOf($expr.ast, $typeIs.ast);
		}
	| parent = arithmeticExpression DOT child = NAME {$ast = new PathExpression($parent.ast, $child.text);
		}
	| BRACKET_OPEN filter = expression BRACKET_CLOSE
	| function = arithmeticExpression pm = parameters {$ast = new FunctionInvocation($function.ast, $pm.ast);
		}
	| lit = literal {$ast = $lit.ast;}
	| simplePositiveUnaryTest {$ast = new TestWrapper($simplePositiveUnaryTest.ast);}
	| token = identifier {$ast = new Name($token.textVal);}
	| PAREN_OPEN arithmeticExpression {$ast = $arithmeticExpression.ast;} PAREN_CLOSE;

//Function Invocation
parameters
	returns[IExpression ast]:
	PAREN_OPEN (
		(namedParameters {$ast = $namedParameters.ast;})
		| (
			positionalParameters {$ast = $positionalParameters.ast;}
		)
	) PAREN_CLOSE;

namedParameters
	returns[IExpression ast]:
	{Dictionary<string, IExpression> parameters = new Dictionary<string, IExpression>();} name =
		parameterName COLON value = expression {parameters.Add($name.text, $value.ast);} (
		COMMA name = parameterName COLON value = expression {parameters.Add($name.text, $value.ast);
			}
	)* {$ast = new NamedParameters(parameters);};

positionalParameters
	returns[IExpression ast]:
	{List<IExpression> parameters = new List<IExpression>();} (
		param = expression {parameters.Add($param.ast);} (
			COMMA param = expression {parameters.Add($param.ast);}
		)*
	) {$ast = new PositionalParameters(parameters);};

//Literals
endpoint
	returns[IExpression ast]:
	simpleValue {$ast = $simpleValue.ast;};

simpleValue
	returns[IExpression ast]:
	(simpleLiteral {$ast = $simpleLiteral.ast; })
	| ( qualifiedName {$ast = $qualifiedName.ast; });

typeIs
	returns[IExpression ast]:
	qualifiedName {$ast = new TypeIs($qualifiedName.ast);};

qualifiedName
	returns[IExpression ast]:
	{List<string> namelist = new List<string>();} name = identifier {namelist.Add($name.textVal);} (
		DOT name = identifier {namelist.Add($name.textVal);}
	)* {$ast = new QualifiedName(namelist);};

literal
	returns[IExpression ast]: (
		simpleLiteral {$ast = $simpleLiteral.ast; }
	)
	| ( NULL {$ast = new NullLiteral();});

simpleLiteral
	returns[IExpression ast]:
	(numericLiteral {$ast = $numericLiteral.ast; })
	| ( stringLiteral {$ast = $stringLiteral.ast; })
	| ( booleanLiteral {$ast = $booleanLiteral.ast; })
	| ( dateTimeLiteral {$ast = $dateTimeLiteral.ast; });

dateTimeLiteral
	returns[IExpression ast]:
	(kind = DATETIMELIT) PAREN_OPEN dateString = stringLiteral {$ast = new DateTimeLiteral($kind.text, $dateString.ast);
		} PAREN_CLOSE;

identifier
	returns[string textVal]: (
		token = NAME {$textVal += $token.text;} (
			token2 = NAME {$textVal += " " + $token2.text;}
		)*
	)
	| token = DATETIMELIT {$textVal = $token.text;};
// | ( token = OR {$textVal = $token.text;}) | ( token = AND {$textVal = $token.text;});

stringLiteral
	returns[IExpression ast]:
	lit = STRING {$ast = new StringLiteral( $lit.text);};

booleanLiteral
	returns[IExpression ast]: (
		lit = TRUE {$ast = new BooleanLiteral( $lit.text);}
		| lit = FALSE {$ast = new BooleanLiteral( $lit.text);}
	);

numericLiteral
	returns[IExpression ast]:
	lit = NUMBER {$ast = new NumericLiteral( $lit.text);};

intervalStartPar
	returns[string textVal]:
	(token = PAREN_OPEN {$textVal = $token.text;})
	| ( token = BRACKET_CLOSE {$textVal = $token.text;})
	| ( token = BRACKET_OPEN {$textVal = $token.text;});

intervalEndPar
	returns[string textVal]:
	(token = PAREN_CLOSE {$textVal = $token.text;})
	| ( token = BRACKET_OPEN {$textVal = $token.text;})
	| ( token = BRACKET_CLOSE {$textVal = $token.text;});

parameterName
	returns[string textVal]:
	token = NAME {$textVal = $token.text;};

key
	returns[string textVal]:
	identifier {$textVal = $identifier.textVal;}
	| stringLiteral {var stringLitVar = $stringLiteral.ast.Execute(); $textVal = ((Variable)stringLitVar).StringVal;
		}; 