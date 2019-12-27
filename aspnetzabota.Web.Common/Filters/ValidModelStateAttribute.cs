using System.Linq;
using aspnetzabota.Common.Result;
using aspnetzabota.Common.Result.ErrorCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace aspnetzabota.Web.Common.Filters
{
    public class ValidModelStateAttribute : ActionFilterAttribute
    {
        public ZabotaErrorCodes ErrorCode = ZabotaErrorCodes.InvalidForm;

        // TODO: move messages in separate place
        public string ErrorMessage { get; set; }

        private const string DefaultErrorMessage = "Введены некорректные данные";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            if (!string.IsNullOrWhiteSpace(ErrorMessage))

                context.Result = new JsonResult(new ZabotaResult { Error = new ZabotaError { Code = ErrorCode, Message = ErrorMessage } });

            var errorMessage = string.Join(", ", context.ModelState.Select(u => u.Value).SelectMany(u => u.Errors).Select(u => u.ErrorMessage));
            context.Result = new JsonResult(new ZabotaResult { Error = new ZabotaError { Code = ErrorCode, Message = errorMessage } });
        }
    }
}