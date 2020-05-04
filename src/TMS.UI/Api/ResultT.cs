using System;

namespace TMS.UI.Api
{
    public readonly struct Result<T>
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (IsFailed)
                {
                    throw new NullReferenceException("Cannot access value of failed result");
                }
                return _value;
            }
        }
        public bool IsOk { get; }
        public bool IsFailed => !IsOk;
        public string Message { get; }

        private Result(T value, bool isOk, string message)
        {
            _value = value;
            IsOk = isOk;
            Message = message;
        }
        
        public static Result<T> Ok(T value) => new Result<T>(value, true, "Ok");
        public static Result<T> Failed(string message) => new Result<T>(default(T), false, message);
        public static Result<T> Forbidden() => new Result<T>(default(T), false, "Forbidden");
    }
}