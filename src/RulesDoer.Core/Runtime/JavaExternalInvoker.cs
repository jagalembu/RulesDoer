using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using RulesDoer.Core.Runtime.Context;
using RulesDoer.Core.Types;

namespace RulesDoer.Core.Runtime {
    public static class JavaExternalInvoker {

        public static Variable Invoke (string javaClass, string methodSig, List<Variable> inputParams) {
            try {
                var (methodName, javaParamTypes) = ParseSignature (methodSig);

                switch (javaClass) {
                    case "java.lang.Math":
                        return InvokeMath (methodName, javaParamTypes, inputParams);
                    case "java.lang.String":
                        return InvokeString (methodName, javaParamTypes, inputParams);
                    case "java.lang.Integer":
                    case "java.lang.Long":
                    case "java.lang.Short":
                    case "java.lang.Byte":
                    case "java.lang.Float":
                    case "java.lang.Double":
                        return InvokeNumericWrapper (javaClass, methodName, javaParamTypes, inputParams);
                    default:
                        return new Variable (); // Unknown class → null
                }
            } catch {
                return new Variable ();
            }
        }

        private static (string name, string[] paramTypes) ParseSignature (string sig) {
            var parenIdx = sig.IndexOf ('(');
            if (parenIdx < 0) return (sig.Trim (), Array.Empty<string> ());
            var name = sig.Substring (0, parenIdx).Trim ();
            var endParen = sig.LastIndexOf (')');
            var paramsStr = endParen > parenIdx
                ? sig.Substring (parenIdx + 1, endParen - parenIdx - 1).Trim ()
                : "";
            if (string.IsNullOrEmpty (paramsStr))
                return (name, Array.Empty<string> ());
            var types = paramsStr.Split (',');
            for (int i = 0; i < types.Length; i++)
                types[i] = types[i].Trim ();
            return (name, types);
        }

        private static Variable InvokeMath (string methodName, string[] javaParamTypes, List<Variable> inputParams) {
            if (javaParamTypes.Length != inputParams.Count) return new Variable ();

            var dotNetTypes = new Type[javaParamTypes.Length];
            for (int i = 0; i < javaParamTypes.Length; i++) {
                dotNetTypes[i] = MapJavaPrimitiveToNetType (javaParamTypes[i]);
                if (dotNetTypes[i] == null) return new Variable (); // unsupported type → null (incorrect_003)
            }

            var method = typeof (Math).GetMethod (methodName,
                BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase,
                null, dotNetTypes, null);
            if (method == null) return new Variable ();

            var args = new object[inputParams.Count];
            for (int i = 0; i < inputParams.Count; i++) {
                args[i] = ConvertToNetType (inputParams[i], dotNetTypes[i]);
                if (args[i] == null) return new Variable ();
            }

            var result = method.Invoke (null, args);
            return ConvertToVariable (result);
        }

        private static Variable InvokeString (string methodName, string[] javaParamTypes, List<Variable> inputParams) {
            switch (methodName.ToLowerInvariant ()) {
                case "valueof":
                    // String.valueOf(char) — input must be a single-character string
                    if (javaParamTypes.Length == 1 && javaParamTypes[0] == "char") {
                        if (inputParams.Count != 1) return new Variable ();
                        var s = inputParams[0].StringVal;
                        if (s == null || s.Length != 1) return new Variable ();
                        return s;
                    }
                    return new Variable ();

                case "format":
                    // Java printf-style format: format(String, args...)
                    if (inputParams.Count < 1) return new Variable ();
                    var fmt = inputParams[0].StringVal;
                    if (fmt == null) return new Variable ();
                    var formatted = JavaFormat (fmt, inputParams, 1);
                    return formatted != null ? (Variable) formatted : new Variable ();

                default:
                    return new Variable ();
            }
        }

        private static Variable InvokeNumericWrapper (string javaClass, string methodName, string[] javaParamTypes, List<Variable> inputParams) {
            if (!methodName.Equals ("valueOf", StringComparison.OrdinalIgnoreCase)) return new Variable ();
            if (javaParamTypes.Length != 1 || inputParams.Count != 1) return new Variable ();

            var paramType = javaParamTypes[0];
            var input = inputParams[0];

            switch (javaClass) {
                case "java.lang.Integer":
                    if (paramType == "java.lang.String") {
                        if (input.ValueType != DataTypeEnum.String) return new Variable ();
                        return int.TryParse (input.StringVal, out var intVal)
                            ? (Variable) (decimal) intVal
                            : new Variable ();
                    }
                    if (paramType == "int") return (Variable) (decimal) (int) input.NumericVal;
                    return new Variable ();

                case "java.lang.Long":
                    if (paramType == "long") return (Variable) (decimal) (long) input.NumericVal;
                    return new Variable ();

                case "java.lang.Short":
                    if (paramType == "short") {
                        var n = (long) input.NumericVal;
                        if (n < short.MinValue || n > short.MaxValue) return new Variable ();
                        return (Variable) (decimal) (short) n;
                    }
                    return new Variable ();

                case "java.lang.Byte":
                    if (paramType == "byte") {
                        var n = (long) input.NumericVal;
                        if (n < sbyte.MinValue || n > sbyte.MaxValue) return new Variable ();
                        return (Variable) (decimal) (sbyte) n;
                    }
                    return new Variable ();

                case "java.lang.Float":
                    if (paramType == "java.lang.String") {
                        if (input.ValueType != DataTypeEnum.String) return new Variable ();
                        return float.TryParse (input.StringVal, NumberStyles.Any, CultureInfo.InvariantCulture, out var fVal)
                            ? (Variable) decimal.Parse (fVal.ToString ("R", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)
                            : new Variable ();
                    }
                    return new Variable ();

                case "java.lang.Double":
                    if (paramType == "java.lang.String") {
                        if (input.ValueType != DataTypeEnum.String) return new Variable ();
                        return double.TryParse (input.StringVal, NumberStyles.Any, CultureInfo.InvariantCulture, out var dVal)
                            ? (Variable) decimal.Parse (dVal.ToString ("R", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture)
                            : new Variable ();
                    }
                    return new Variable ();

                default:
                    return new Variable ();
            }
        }

        private static string JavaFormat (string fmt, List<Variable> args, int startIdx) {
            var sb = new StringBuilder ();
            int argIdx = startIdx;
            for (int i = 0; i < fmt.Length; i++) {
                if (fmt[i] == '%' && i + 1 < fmt.Length) {
                    var spec = fmt[i + 1];
                    if (spec == 's' || spec == 'd' || spec == 'f') {
                        if (argIdx >= args.Count) return null;
                        var arg = args[argIdx++];
                        sb.Append (arg.ValueType == DataTypeEnum.String
                            ? arg.StringVal
                            : arg.NumericVal.ToString (CultureInfo.InvariantCulture));
                        i++;
                    } else {
                        sb.Append (fmt[i]);
                    }
                } else {
                    sb.Append (fmt[i]);
                }
            }
            return sb.ToString ();
        }

        private static Type MapJavaPrimitiveToNetType (string javaType) {
            switch (javaType) {
                case "double": return typeof (double);
                case "float": return typeof (float);
                case "int": return typeof (int);
                case "long": return typeof (long);
                case "short": return typeof (short);
                case "byte": return typeof (sbyte);
                case "char": return typeof (char);
                case "java.lang.String": return typeof (string);
                case "java.lang.Object": return typeof (object);
                default: return null; // Unknown type → causes method-not-found
            }
        }

        private static object ConvertToNetType (Variable v, Type targetType) {
            if (targetType == typeof (double)) return (double) v.NumericVal;
            if (targetType == typeof (float)) return (float) v.NumericVal;
            if (targetType == typeof (int)) return (int) v.NumericVal;
            if (targetType == typeof (long)) return (long) v.NumericVal;
            if (targetType == typeof (short)) return (short) v.NumericVal;
            if (targetType == typeof (sbyte)) return (sbyte) v.NumericVal;
            if (targetType == typeof (char)) {
                var s = v.StringVal;
                return (s != null && s.Length == 1) ? (object) s[0] : null;
            }
            if (targetType == typeof (string)) return v.StringVal;
            if (targetType == typeof (object)) return (object) (v.StringVal ?? v.NumericVal.ToString (CultureInfo.InvariantCulture));
            return null;
        }

        private static Variable ConvertToVariable (object result) {
            if (result == null) return new Variable ();
            if (result is double d) return decimal.Parse (d.ToString ("R", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            if (result is float f) return decimal.Parse (f.ToString ("R", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
            if (result is int i) return (decimal) i;
            if (result is long l) return (decimal) l;
            if (result is short s) return (decimal) s;
            if (result is sbyte b) return (decimal) b;
            if (result is string str) return str;
            if (result is bool bv) return bv;
            return new Variable ();
        }
    }
}
