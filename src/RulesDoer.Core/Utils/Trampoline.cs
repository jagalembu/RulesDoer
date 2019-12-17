using System;

namespace RulesDoer.Core.Utils {
    public static class Trampoline {
        public static TResult Start<T1, T2, T3, TResult> (Func<T1, T2, Bounce<T1, T2, TResult>> action,
            T1 arg1, T2 arg2) {
            TResult result = default (TResult);
            Bounce<T1, T2, TResult> bounce = Bounce<T1, T2, TResult>.Continue (arg1, arg2);

            while (true) {
                if (bounce.HasResult) {
                    result = bounce.Result;
                    break;
                }

                bounce = action (bounce.Arg1, bounce.Arg2);
            }

            return result;
        }
    }
}