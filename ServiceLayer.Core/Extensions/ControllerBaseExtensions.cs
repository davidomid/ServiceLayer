using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Extensions;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TResultType>(this ControllerBase controller, IServiceResult<TResultType> serviceResult) where TResultType : struct, Enum
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult<HttpStatusCode> httpServiceResult)
        {
            return httpServiceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData> serviceResult)
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData, TResultType>(this ControllerBase controller, IDataServiceResult<TData, TResultType> serviceResult) where TResultType : struct, Enum
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData, HttpStatusCode> httpServiceResult)
        {
            return httpServiceResult.ToActionResult();
        }
    }
}