using System.Collections.Generic;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime {
    public static class TypeCoercionHelper {

        public static Variable Coerce (Variable result, string typeRef, Dictionary<string, ItemDefinitionMeta> itemDefs) {
            if (result == null || result.ValueType == DataTypeEnum.Null)
                return new Variable ();

            if (result.ValueType == DataTypeEnum.DecisionTableResult)
                return result;

            if (string.IsNullOrEmpty (typeRef))
                return result;

            if (itemDefs != null && itemDefs.TryGetValue (typeRef, out var itemDef)) {
                if (itemDef.IsCollection)
                    return CoerceToCollection (result, itemDef, itemDefs);
                if (itemDef.ItemComponents.Count > 0)
                    return CoerceToContext (result, itemDef, itemDefs);
                if (!string.IsNullOrEmpty (itemDef.TypeName))
                    return Coerce (result, itemDef.TypeName, itemDefs);
            }

            return CoerceToPrimitive (result, typeRef);
        }

        private static Variable CoerceToPrimitive (Variable result, string typeRef) {
            if (typeRef == "list")
                return result.IsListType () ? result : new Variable ();

            if (typeRef == "Any" || typeRef == "any")
                return result;

            var expectedType = MapTypeRefToDataType (typeRef);
            if (expectedType == null)
                return result;

            if (result.ValueType == expectedType.Value)
                return result;

            if (result.IsListType () && result.ListVal?.Count == 1) {
                var elem = result.ListVal[0];
                if (elem.ValueType == expectedType.Value) return elem;
                return new Variable ();
            }

            return new Variable ();
        }

        private static Variable CoerceToCollection (Variable result, ItemDefinitionMeta itemDef, Dictionary<string, ItemDefinitionMeta> itemDefs) {
            if (result.ValueType == DataTypeEnum.Null)
                return new Variable ();

            if (!result.IsListType ())
                return new Variable ();

            if (result.ListVal != null && !string.IsNullOrEmpty (itemDef.TypeName)) {
                foreach (var elem in result.ListVal) {
                    var coerced = Coerce (elem, itemDef.TypeName, itemDefs);
                    if (coerced.ValueType == DataTypeEnum.Null && elem.ValueType != DataTypeEnum.Null)
                        return new Variable ();
                }
            }

            return result;
        }

        private static Variable CoerceToContext (Variable result, ItemDefinitionMeta itemDef, Dictionary<string, ItemDefinitionMeta> itemDefs) {
            if (result.ValueType != DataTypeEnum.Context)
                return new Variable ();

            foreach (var component in itemDef.ItemComponents) {
                result.ContextInputs.ContextDict.TryGetValue (component.Key, out var fieldVal);
                if (fieldVal == null)
                    return new Variable ();
                if (fieldVal.ValueType == DataTypeEnum.Null)
                    continue;

                var coerced = Coerce (fieldVal, component.Value.TypeName, itemDefs);
                if (coerced.ValueType == DataTypeEnum.Null)
                    return new Variable ();
            }

            return result;
        }

        private static DataTypeEnum? MapTypeRefToDataType (string typeRef) {
            switch (typeRef.ToLowerInvariant ()) {
                case "string": return DataTypeEnum.String;
                case "number":
                case "decimal":
                case "double": return DataTypeEnum.Decimal;
                case "boolean": return DataTypeEnum.Boolean;
                case "date": return DataTypeEnum.Date;
                case "date and time": return DataTypeEnum.DateTime;
                case "time": return DataTypeEnum.Time;
                case "years and months duration": return DataTypeEnum.YearMonthDuration;
                case "days and time duration": return DataTypeEnum.DayTimeDuration;
                default: return null;
            }
        }
    }
}
