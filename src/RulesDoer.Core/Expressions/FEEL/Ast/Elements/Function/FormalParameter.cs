using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Expressions.FEEL.Ast.Elements.Function {
    public class FormalParameter : IExpression {
        private readonly string _name;
        private readonly IExpression _type;

        private readonly string _typeName;

        public FormalParameter (string name, IExpression type) {
            _name = name;
            _type = type;
        }

        public FormalParameter (string name, string typeName) {
            _name = name;
            _typeName = typeName;
        }

        public object Execute (VariableContext context = null) {

            if (_typeName == null) {
                return new Variable (_name, "__none__");
            }

            var typeName = (Variable) _type.Execute (context);

            typeName.ExpectedDataType (DataTypeEnum.String);

            return new Variable (_name, typeName);

        }

    }
}