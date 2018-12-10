using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult FromServiceResult<TResultType, TData>(this ControllerBase controller, IGenericServiceResult<TResultType, TData> serviceResult) where TResultType : Enum
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok(serviceResult.Data); 
            }
            return controller.StatusCode(500, serviceResult.ErrorMessages);
        }

        public static IActionResult FromServiceResult<TResultType>(this ControllerBase controller, IGenericServiceResult<TResultType> serviceResult) where TResultType : Enum
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok();
            }
            return controller.StatusCode(500, serviceResult.ErrorMessages);
        }

        public static IActionResult FromServiceResult<TData>(this ControllerBase controller, HttpServiceResult<TData> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return controller.Ok(httpServiceResult.Data);
                
                default:
                    return controller.FromNonGenericServiceResult(httpServiceResult); 
            }
        }

        public static IActionResult FromServiceResult(this ControllerBase controller, HttpServiceResult httpServiceResult)
        {
            return controller.FromNonGenericServiceResult(httpServiceResult); 
        }

        private static IActionResult FromNonGenericServiceResult(this ControllerBase controller, HttpServiceResult httpServiceResult)
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