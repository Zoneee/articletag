using System;

namespace Common
{
    public static class PipeLineOperator
    {
        public static TU Pipe<T, TU>(this T input, Func<T, TU> fun) => fun(input);

        public static void Pipe<T>(this T input, Action<T> fun) => fun(input);
    }
}
