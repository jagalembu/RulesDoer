using System;
using RulesDoer.Core.Expressions.FEEL.Ast.Elements.Literal;
using RulesDoer.Core.Expressions.FEEL.Eval;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.EvalTest {
    public class PositiveUnaryTest : ITestExpression {
        private readonly IEle Expression;

        public PositiveUnaryTest (IEle expression) {
            Expression = expression;
        }

        public object Execute (VariableContext context = null, string inputName = null) {

            if (Expression is TestWrapper testwrap) {
                testwrap.InputDataName = inputName;
                return testwrap.Execute (context);
            }

            if (Expression is IExpression expr) {

                var inputVariable = VariableContextHelper.RetrieveInputVariable (context, inputName);

                if (Expression is ListLiteral lt) {
                    foreach (var listExpr in lt.Expressions) {
                        if (listExpr is TestWrapper tW) {
                            tW.InputDataName = inputName;
                            Variable twBool = null;
                            try {
                                twBool = (Variable) tW.Execute (context);
                                if (twBool.ValueType == DataTypeEnum.Boolean) {
                                    if (twBool.BoolVal) {
                                        return new Variable (true);
                                    }
                                } else {
                                    throw new ArgumentException ($"Expected a test condition result of boolean not:{twBool.ValueType}");
                                }
                            } catch (FEELException) {
                                //do nothing skip not matching types
                            } catch (Exception ex) {
                                throw ex;
                            }

                        }
                        else if (listExpr is IExpression regExpr) {
                            var regVar = (Variable) regExpr.Execute (context);
                            if (regVar.Equals (inputVariable)) {
                                return new Variable (true);
                            }
                        }
                    }
                    return new Variable (false);
                }

                var exprVar = (Variable) expr.Execute (context);

                if (inputVariable.ValueType != exprVar.ValueType) {
                    throw new FEELException ($"Left value {inputVariable.ValueType} and right {exprVar.ValueType} are not the same for comparison");
                }

                return new Variable (inputVariable.Equals (exprVar));
            }

            if (Expression is ITestExpression texpr) {
                return texpr.Execute (context, inputName);
            }

            throw new FEELException ("Unexepected type of expression for positive unary test");

        }
    }
}