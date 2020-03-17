using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public class ApiResult
    {
        public ApiResultStatus Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    public class ApiResult<T> where T : class
    {
        public ApiResultStatus Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public enum ApiResultStatus
    {
        Exprired = -2,
        Failed = -1,
        NotAuth = 0,
        Success = 1
    }
}
