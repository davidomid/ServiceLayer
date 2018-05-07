using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromResult<T>(this ControllerBase controller, ServiceResult<T> result)
        {
            switch (result.ResultType)
            {
                case ServiceResultTypes.Ok:
                    return controller.Ok(result.Data);
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