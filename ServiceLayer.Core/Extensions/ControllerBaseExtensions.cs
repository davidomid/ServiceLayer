using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromResult(this ControllerBase controller, IServiceResult result)
        {
            return controller.FromNonGenericResult(result);
        }

        public static ActionResult FromResult<T>(this ControllerBase controller, IServiceResult<T> result)
        {
            switch (result.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok(result.Data);
                default:
                    return controller.FromNonGenericResult(result);
            }
        }

        private static ActionResult FromNonGenericResult(this ControllerBase controller, IServiceResult result)
        {
            switch (result.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok();
                case ServiceResultTypes.NotFound:
                    return controller.NotFound();
                case ServiceResultTypes.BadRequest:
                    return controller.BadRequest(result.ErrorMessages);
                case ServiceResultTypes.Error:
                    return controller.StatusCode(500, result.ErrorMessages);
                default:
                    throw new ArgumentOutOfRangeException(
                        $"No action result could be returned for service result type {result.ResultType}");
            }
        }
    }
}