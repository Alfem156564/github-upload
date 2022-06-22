namespace Common.Models
{
    using Common.Enumerations;

    public class ManagerResult<T>
    {
        public static ManagerResult<T> FromSuccess(T value) => new ManagerResult<T> { DidSucceed = true, Value = value };

        public static ManagerResult<T> FromError(ErrorCodes errorCode) => new ManagerResult<T> { DidSucceed = false, ErrorCode = errorCode };

        public T Value { get; set; }

        public string ErrorMessage { get; set; }

        public ErrorCodes ErrorCode { get; set; }

        public bool DidSucceed { get; set; }
    }
}
