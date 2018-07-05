using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static IActionResult FromServiceResult(this ControllerBase controller, IServiceResult result)
        {
            return controller.FromNonGenericServiceResult(result);
        }

        public static IActionResult FromServiceResult<T>(this ControllerBase controller, IServiceResult<T> result)
        {
            switch (result.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok(result.Data);
                default:
                    return controller.FromNonGenericServiceResult(result);
            }
        }

        private static IActionResult FromNonGenericServiceResult(this ControllerBase controller, IServiceResult result)
        {
            switch (result.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok();
                case ServiceResultTypes.NotFound:
                    return controller.NotFound();
                case ServiceResultTypes.BadRequest:
                    return controller.BadRequest(result.ErrorMessages);
                case ServiceResultTypes.Conflict:
                    return controller.StatusCode(409, result.ErrorMessages);
                case ServiceResultTypes.Error:
                    return controller.StatusCode(500, result.ErrorMessages);
                default:
                    throw new ArgumentOutOfRangeException(
                        $"No action result could be returned for service result type {result.ResultType}");
            }
        }
    }
}