using System.Collections.Generic;

namespace ShoutOutApi.Helpers
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public bool Failed { get; set; }

        public readonly IList<string> Errors;

        private Result(string[] errors)
        {
            Errors = errors;
            Failed = true;
        }

        private Result()
        {
            IsSuccess = true;
            Failed = false;
        }

        public static Result Fail(string[] errors)
        {
            return new Result(errors);
        }

        public static Result Success()
        {
            return new Result();
        }
    }

    public class Result<T>
    {
    }
}
