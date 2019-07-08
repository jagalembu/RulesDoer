parser grammar FEELGrammar;

options {
	tokenVocab = FEELLexer;
}

@header {

}

@parser::members {

}

//Base Rules
expression: textualExpression EOF;

simpleExpressions:
	simpleExpression (COMMA exp = simpleExpression)* EOF;

//Tests

//Expression
simpleExpression: (arithmeticExpression)	# arithmeticExpr
	| (simpleValue)							# simpleValueExpr;

textualExpression:
	(forExpression)				# forExpr
	| (ifExpression)			# ifExpr
	| (quantifiedExpression)	# quantifiedExpr
	| (disjunction)				# disjunctionExpr;

//logic
forExpression:
	FOR var = identifier IN domain = iterationContext (
		COMMA var = identifier IN domain = iterationContext
	)* RETURN body = expression;

iterationContext:
	left = expression (DOT_DOT right = expression)?;

ifExpression:
	IF cond = expression THEN exprOne = expression ELSE exprTwo = expression;

quantifiedExpression:
	(op = SOME | op = EVERY) var = identifier IN domain = expression (
		var = identifier IN domain = expression
	)* SATISFIES body = expression;

disjunction: left = conjunction (OR right = conjunction)*;

conjunction: left = comparison (AND right = comparison)*;

comparison:
	firstAst = arithmeticExpression (
		(
			(
				op = EQ
				| op = NE
				| op = LT
				| op = GT
				| op = LE
				| op = GE
			) secondAst = arithmeticExpression
		)
		| (BETWEEN left = expression AND right = expression)
	)?;
//| expression , "in" , positive unary test | expression , "in" , " (", positive unary tests, ")" ;

//Arithmetics
arithmeticExpression: addition;

addition: left = subtraction (PLUS right = subtraction)*;

subtraction:
	left = multiplication (MINUS right = multiplication)*;

multiplication: left = division (STAR right = division)*;

division:
	left = exponentiation (FORWARD_SLASH right = exponentiation)*;

exponentiation:
	left = arithmeticNegation (
		STAR_STAR right = arithmeticNegation
	)*;

arithmeticNegation: (MINUS)* expr = literal;

//Literals
simpleValue:
	(simpleLiteral)		# simpleLiteralExpr
	| ( qualifiedName)	# qualifiedNameExpr;

qualifiedName: name = identifier ( DOT name = identifier)*;

literal: (simpleLiteral) # simpleLitExpr | ( NULL) # nullExpr;

simpleLiteral:
	(numericLiteral)		# numericLiteralExpr
	| ( stringLiteral)		# stringLiteralExpr
	| ( booleanLiteral)		# booleanLiteralExpr
	| ( dateTimeLiteral)	# dateTimeLiteralExpr;

dateTimeLiteral:
	(kind = identifier) PAREN_OPEN stringLiteral PAREN_CLOSE;

identifier: ( token = NAME) | ( token = OR) | ( token = AND);

stringLiteral: lit = STRING;

booleanLiteral: (lit = TRUE | lit = FALSE);

numericLiteral: lit = NUMBER;

intervalStartPar:
	(token = PAREN_OPEN)
	| ( token = BRACKET_CLOSE)
	| ( token = BRACKET_OPEN);

intervalEndPar:
	(token = PAREN_CLOSE)
	| ( token = BRACKET_OPEN)
	| ( token = BRACKET_CLOSE);