namespace TMS.Api.Games
{
    public struct Result
    {
        public bool Success { get; }
        public string Message { get; }

        private Result(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        
        public static Result Ok() => new Result(true, "ok");
        public static Result Failed(string message) => new Result(false, message);
    }
}