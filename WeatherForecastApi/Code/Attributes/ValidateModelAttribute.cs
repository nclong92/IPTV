using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Code.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {

                var message = string.Empty;
                foreach (var state in context.ModelState.Values)
                {
                    if (state.Errors.Count > 1)
                    {
                        foreach (var error in state.Errors)
                        {

                            message += $"{error.ErrorMessage}. ";
                        }
                    }
                }

                var obj = new ApiResult()
                {
                    Status = ApiResultStatus.Failed,
                    Message = message
                };
                context.Result = new JsonResult(obj);// new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
