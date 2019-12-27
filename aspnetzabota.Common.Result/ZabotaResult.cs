using System.Diagnostics;
using aspnetzabota.Common.Result.ErrorCodes;

namespace aspnetzabota.Common.Result
{
    [DebuggerDisplay("[IsCorrect: {IsCorrect}]{Error}")]
    public class ZabotaResult
    {
        public ZabotaError Error { get; set; }

        public bool IsCorrect => Error == null || Error.Code == ErrorCodes.ZabotaErrorCodes.Ok;
        public bool IsNotCorrect => !IsCorrect;

        public ZabotaResult()
        {
        }

        public static implicit operator ZabotaResult(ZabotaErrorCodes error) => new ZabotaResult(ZabotaError.FromCode(error));
        public static implicit operator ZabotaResult(ZabotaError error) => new ZabotaResult(error);

        public ZabotaResult(ZabotaError error)
        {
            Error = error;
        }

        public ZabotaResult ConvertWithError<K>()
        {
            return new ZabotaResult(Error);
        }
    }

    [DebuggerDisplay("[IsCorrect: {IsCorrect}][Result: {Result}]{Error}")]
    public class ZabotaResult<T> : ZabotaResult
    {
        public ZabotaResult()
        {
        }

        public ZabotaResult(ZabotaError error) : base(error)
        {
        }

        public ZabotaResult(T result) : base(null)
        {
            Result = result;
        }

        public T Result { get; set; }

        public static implicit operator ZabotaResult<T>(ZabotaErrorCodes error) => new ZabotaResult<T>(ZabotaError.FromCode(error));
        public static implicit operator ZabotaResult<T>(ZabotaError zabotaError) => new ZabotaResult<T>(zabotaError);

        public static ZabotaResult<T> FromCode(ZabotaErrorCodes code, string message = null)
        {
            return new ZabotaResult<T>(ZabotaError.FromCode(code, message));
        }
    }
}