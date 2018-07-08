using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult FromServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            return controller.FromNonGenericServiceResult(serviceResult);
        }

        public static IActionResult FromServiceResult<T>(this ControllerBase controller, IServiceResult<T> serviceResult)
        {
            switch (serviceResult.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok(serviceResult.Data);
                default:
                    return controller.FromNonGenericServiceResult(serviceResult);
            }
        }

        private static IActionResult FromNonGenericServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            switch (serviceResult.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok();
                case ServiceResultTypes.NotFound:
                    return controller.NotFound();
                case ServiceResultTypes.BadRequest:
                    return controller.BadRequest(serviceResult.ErrorMessages);
                case ServiceResultTypes.Conflict:
                    return controller.StatusCode(409, serviceResult.ErrorMessages);
                case ServiceResultTypes.ServiceError:
                    return controller.StatusCode(500, serviceResult.ErrorMessages);
                default:
                    throw new ArgumentOutOfRangeException(
                        $"No action result could be returned for service result type {serviceResult.ResultType}");
            }
        }
    }
}