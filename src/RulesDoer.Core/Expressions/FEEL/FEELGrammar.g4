parser grammar FEELGrammar;

options {
	tokenVocab = FEELLexer;
}

@header {

}

@parser::members {

}

// expression : boxedexpression | textualexpression ;

// textualexpression: forexpression | ifexpression | quantifiedexpression | disjunction |
// conjunction | comparison | arithmeticexpression | instanceof | pathexpression | filterexpression
// | functioninvocation | literal | simplepositiveunarytest | name | (, textualexpression,);

// textualexpressions: textualexpression, { "," , textualexpression };

// arithmeticexpression : addition | subtraction | multiplication | division | exponentiation |
// arithmeticnegation;

// simpleexpression : arithmeticexpression | simplevalue;

// simpleexpressions : simpleexpression, { "," , simpleexpression };

// simplepositiveunarytest : [ "<" | "<=" | ">" | ">=" ], endpoint | interval;

// interval : (openintervalstart | closedintervalstart), endpoint, .., endpoint, ( openintervalend |
// closedintervalend );

// openintervalstart : ( |;

// closedintervalstart :[" ;

// openintervalend : ")" | "[" ;

// closedintervalend : "]" ;

// simplepositiveunarytests : simplepositiveunarytest , { "," , simplepositiveunarytest } ;

// simpleunarytests : simplepositiveunarytests | "not", "(", simple positive unary tests, ")" | "-";

// positiveunarytest : expression ;

// positiveunarytests : positiveunarytest , { "," , positiveunarytest } ;

// unarytests : positiveunarytests | "not", " (", positiveunarytests, ")" | "-";

// endpoint : simplevalue ;

// simplevalue : qualifiedname | simpleliteral ;

// qualifiedname : name , { "." , name } ;

// addition : expression , "+" , expression ;

// subtraction : expression , "-" , expression ;

// multiplication : expression , "*" , expression ;

// division : expression , "/" , expression ;

// exponentiation : expression, "**", expression ;

// arithmeticnegation : "-" , expression ;

// name : namestart , { namepart | additionalnamesymbols } ;

// namestart : namestartchar, { namepartchar } ;

// namepart : namepartchar , { namepartchar } ;

// namestartchar : "?" | [A-Z] | "_" | [a-z] | [\uC0-\uD6] | [\uD8-\uF6] | [\uF8-\u2FF] | [\u370-\u37D] | [\u37F-\u1FFF] | [\u200C-\u200D] | [\u2070-\u218F] | [\u2C00-\u2FEF] | [\u3001-\uD7FF] | [\uF900-\uFDCF] | [\uFDF0-\uFFFD] | [\u10000-\uEFFFF] ;

// namepartchar : namestartchar | digit | \uB7 | [\u0300-\u036F] | [\u203F-\u2040] ;

// additionalnamesymbols : "." | "/" | "-" | "’" | "+" | "*" ;

// literal : simpleliteral | "null" ;

// simpleliteral : numericliteral | stringliteral | booleanliteral | datetimeliteral ;

// stringliteral : """, { character – (""" | verticalspace) | stringescapesequence}, """ ;

// booleanliteral : "true" | "false" ;

// numericliteral : [ "-" ] , ( digits , [ ".", digits ] | "." , digits ) ;

// digit : [0-9] ;

// digits : digit , {digit} ;

// functioninvocation : expression , parameters ;

// parameters : "(" , ( namedparameters | positionalparameters ) , ")" ;

// namedparameters : parametername , ":" , expression , { "," , parametername , ":" , expression } ;

// parametername : name ;

// positionalparameters : [ expression , { "," , expression } ] ;

// pathexpression : expression , "." , name ;

// forexpression : FOR , name , "in" , iteration context { "," , name , "in" , iteration context } , "return" , expression ;

// ifexpression : "if" , expression , "then" , expression , "else" expression ;

// quantifiedexpression : ("some" | "every") , name , "in" , expression , { "," , name , "in" , expression } , "satisfies" , expression ;

// disjunction : expression , "or" , expression ;

// conjunction : expression , "and" , expression ;

// comparison : expression , ( "=" | "!=" | "<" | "<=" | ">" | ">=" ) , expression | expression ,
// "between" , expression , "and" , expression | expression , "in" , positive unary test |
// expression , "in" , " (", positive unary tests, ")" ;

// filterexpression : expression , "[" , expression , "]" ;

// instanceof : expression , "instance" , "of" , type ;

// type : qualifiedname ;

// boxedexpression : list | function definition | context ;

// list : "[" , [ expression , { "," , expression } ] , "]" ;

// functiondefinition : "function" , "(" , [ formalparameter { "," , formalparameter } ] , ")" , [ "external" ] , expression ;

// formalparameter : parametername [":" type ] ;

// context : "{" , [contextentry , { "," , contextentry } ] , "}" ;

// contextentry : key COLON expression ;

// key : name | stringliteral ;

// datetimeliteral = functioninvocation;

// whitespace : verticalspace | \u0009 | \u0020 | \u0085 | \u00A0 | \u1680 | \u180E | [\u2000-\u200B] | \u2028 | \u2029 | \u202F | \u205F | \u3000 | \uFEFF ;

// verticalspace : [\u000A-\u000D];

// iterationcontext : expression, [ “..”, expression ];

// stringescapesequence : "\'" | "\"" | "\\" | "\n" | "\r" | "\t" | "\u", hex digit, hex digit, hex digit, hex digit;

//Base Rules
expression: textualExpression EOF;

simpleExpressions:
	simpleExpression (COMMA exp = simpleExpression)* EOF;

//Tests

//Expression
simpleExpression: (arithmeticExpression)	# arithmeticExpr
	| (simpleValue)							# simpleValueExpr;

// textualexpression: forexpression | ifexpression | quantifiedexpression | disjunction |
// conjunction | comparison | arithmeticexpression | instanceof | pathexpression | filterexpression
// | functioninvocation | literal | simplepositiveunarytest | name | (, textualexpression,);
textualExpression:
	(forExpression)				# forExpr
	| (ifExpression)			# ifExpr
	| (quantifiedExpression)	# quantifiedExpr
	| (disjunction)				# disjunctionExpr;
	//| (conjunction)				# conjunctionExpr;
	// | (comparison)				# comparisonExpr
	// | (arithmeticExpression)	# arithmeticTxtExpr
	// | (literal)					# literalExpr;
// | conjunction # conjunctionExpr | comparison # comparisonExpr; | arithmeticExpression #
// arithmeticExpr; | instanceof | pathexpression | filterexpression | functioninvocation literal #
// literalExpr; | simplepositiveunarytest | name | (, textualexpression,);

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

subtraction: left = multiplication (MINUS right = multiplication)*;

multiplication: left = division (STAR right = division)*;

division:
	left = exponentiation (FORWARD_SLASH right = exponentiation)*;

exponentiation:
	left = arithmeticNegation (STAR_STAR right = arithmeticNegation)*;

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