﻿using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult FromServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok();
            }
            return controller.StatusCode(500, serviceResult.ErrorDetails);
        }

        public static IActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData> serviceResult)
        {
            if (serviceResult.IsSuccessful)
            {
                return controller.Ok(serviceResult.Data);
            }
            return controller.StatusCode(500, serviceResult.ErrorDetails);
        }

        public static IActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return controller.Ok(httpServiceResult.Data);
                default:
                    return controller.FromServiceResult((IServiceResult<HttpServiceResultTypes>)httpServiceResult);
            }
        }

        public static IActionResult FromServiceResult(this ControllerBase controller, IServiceResult<HttpServiceResultTypes> httpServiceResult)
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
                    return controller.BadRequest(httpServiceResult.ErrorDetails);
                case HttpServiceResultTypes.Conflict:
                    return controller.StatusCode(409, httpServiceResult.ErrorDetails);
                case HttpServiceResultTypes.InternalServerError:
                    return controller.StatusCode(500, httpServiceResult.ErrorDetails);
                default:
                    goto case HttpServiceResultTypes.InternalServerError;
            }
        }
    }
}