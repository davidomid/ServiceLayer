using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult FromServiceResult<TResultType, TData>(this ControllerBase controller, IDataServiceResult<TData, TResultType> serviceResult) where TResultType : Enum
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok(serviceResult.Data); 
            }
            return controller.StatusCode(500, serviceResult.ErrorMessages);
        }

        public static IActionResult FromServiceResult<TResultType>(this ControllerBase controller, IServiceResult<TResultType> serviceResult) where TResultType : Enum
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok();
            }
            return controller.StatusCode(500, serviceResult.ErrorMessages);
        }

        public static IActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return controller.Ok(httpServiceResult.Data);
                
                default:
                    return controller.FromHttpServiceResult(httpServiceResult); 
            }
        }

        public static IActionResult FromServiceResult(this ControllerBase controller, IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            return controller.FromHttpServiceResult(httpServiceResult); 
        }

        private static IActionResult FromHttpServiceResult(this ControllerBase controller, IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return controller.Ok();
                case HttpServiceResultTypes.NotFound:
                    return controller.NotFound();
                case HttpServiceResultTypes.Unauthorized:
                    return controller.Unauthorized();
                case HttpServiceResultTypes.Forbidden:
                    return controller.Forbid();
                case HttpServiceResultTypes.BadRequest:
                    return controller.BadRequest(httpServiceResult.ErrorMessages);
                case HttpServiceResultTypes.Conflict:
                    return controller.StatusCode(409, httpServiceResult.ErrorMessages);
                case HttpServiceResultTypes.InternalServerError:
                    return controller.StatusCode(500, httpServiceResult.ErrorMessages);
                default:
                    throw new NotSupportedException($"No action result could be returned for service result type {httpServiceResult.ResultType}");
            }
        }

    }
}