using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Match {
    public class InstanceOf : IExpression {
        private readonly IExpression _left;
        private readonly IExpression _whichType;

        public InstanceOf (IExpression left, IExpression whichType) {
            _left = left;
            _whichType = whichType;
        }

        public object Execute (VariableContext context = null) {
            var leftVal = _left.Execute (context);
            var whichTypeVal = _whichType.Execute (context);

            if (whichTypeVal is Variable outType && outType.ValueType == DataTypeEnum.String) {
                ValidTypeNames.StringTypeToEnum.TryGetValue (outType.StringVal, out DataTypeEnum outDataType);

                if (leftVal is Variable outLeftVal) {
                    if (outDataType == DataTypeEnum.Any && outLeftVal.ValueType != DataTypeEnum.Null) {
                        return new Variable (true);
                    }
                    if (outLeftVal.ValueType == outDataType) {
                        return new Variable (true);
                    }
                    return new Variable (false);
                }

                return new Variable ();
            }

            return new Variable ();
        }
    }
}