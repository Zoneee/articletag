using System.Collections.Generic;

namespace Businesses.ViewModels
{
    public class JsonResponseBase<T>
    {
        public bool Success { get; set; } = true;
        public int HttpCode { get; set; } = 200;

        /// <summary>
        /// Erro code, it will return 0 when no error
        /// </summary>
        public int ErrorCode { get; set; } = 0;

        public string ErrorMsg { get; set; }
        public T Result { get; set; }

        public static JsonResponseBase<T, IDictionary<string, string[]>> CreateDefault()
            => new JsonResponseBase<T, IDictionary<string, string[]>>()
            {
                ErrorMsgModel = new Dictionary<string, string[]>()
            };
    }

    public class JsonResponseBase<TResult, TErrorMessage> : JsonResponseBase<TResult>
    {
        public TErrorMessage ErrorMsgModel { get; set; } = default;
    }
}
