using System.Diagnostics;
using aspnetzabota.Common.Result.ErrorCodes;

namespace aspnetzabota.Common.Result
{
    [DebuggerDisplay("[Code: {Code}][{Message}]")]
    public class ZabotaError
    {
        public ZabotaErrorCodes Code { get; set; }

        public string Message { get; set; }

        public static implicit operator ZabotaError(ZabotaErrorCodes error) => FromCode(error);

        public static ZabotaError FromCode(ZabotaErrorCodes code, string message = null)
        {
            return new ZabotaError
            {
                Code = code,
                Message = message ?? code.ToFriendlyString()
            };
        }

        public static ZabotaError FromCodeWithArgs(ZabotaErrorCodes code, params object[] args)
        {
            return new ZabotaError
            {  
                Code = code,
                Message = string.Format(code.ToFriendlyString(), args)
            };
        }
    }
}