﻿namespace aspnetzabota.Common.Result.ErrorCodes
{
    public enum ZabotaErrorCodes
    {
        Ok = 1000000,
        FileSizeExceeded = 1000001,
        CannotUploadFile = 1000002,
        InvalidForm = 1000003,
        CannotReadThisFile = 1000004,
        FileNotExist = 1000005,
        UserNotFound = 1000006,
        WrongPassword = 1000007,
        CreateTokenError = 1000008,
        CannotFindToken = 1000009,
        CannotFindIdentityByTokenId = 1000010,
        CannotFindUserProfileByIdentityId = 1000011
    }

    public static class ErrorCodesExtensions
    {
        public static bool IsCorrect(this ZabotaErrorCodes code)
        {
            return code == ZabotaErrorCodes.Ok;
        }

        public static bool IsNotCorrect(this ZabotaErrorCodes code)
        {
            return !code.IsCorrect();
        }

        public static LazuritResult<T> ToErrorResult<T>(this ZabotaErrorCodes code)
        {
            return new LazuritResult<T>(new ZabotaError { Code = code });
        }

        public static string ToFriendlyString(this ZabotaErrorCodes code)
        {
            switch (code)
            {
                default:
                    return code.ToString();
            }
        }

    }
}