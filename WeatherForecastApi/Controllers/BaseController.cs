using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecastApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    //[Benchmark]
    public class BaseController : ControllerBase
    {
        //protected BaseAuthViewModel CurrentUser
        //{
        //    get
        //    {
        //        return BaseAuthViewModel.GetModel(User.Claims);
        //    }
        //}

        protected IActionResult ApiResult(ApiResultStatus status, string message)
        {
            return Ok(new ApiResult
            {
                Status = status,
                Message = message,
            });
        }

        protected IActionResult ApiResultFailed(string message)
        {
            return ApiResult(ApiResultStatus.Failed, message);
        }

        protected IActionResult ApiResultSuccess(string message)
        {
            return ApiResult(ApiResultStatus.Success, message);
        }

        protected IActionResult ApiResult<T>(ApiResultStatus status, string message, T value) where T : class
        {
            return Ok(new ApiResult<T>
            {
                Status = status,
                Message = message,
                Data = value
            });
        }

        protected IActionResult ApiResultSuccess<T>(T value) where T : class
        {
            return Ok(new ApiResult<T>
            {
                Status = ApiResultStatus.Success,
                Message = string.Empty,
                Data = value
            });
        }
    }
}
