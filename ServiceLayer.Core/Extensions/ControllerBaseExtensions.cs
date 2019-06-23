using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromServiceResult(this ControllerBase controller, IResult result)
        {
            return result.ToActionResult();
        }

        public static ActionResult FromServiceResult<TResultType>(this ControllerBase controller, IResult<TResultType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }

        public static ActionResult FromServiceResult(this ControllerBase controller, IResult<HttpStatusCode> httpResult)
        {
            return httpResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataResult<TData> result)
        {
            return result.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData, TResultType>(this ControllerBase controller, IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataResult<TData, HttpStatusCode> httpResult)
        {
            return httpResult.ToActionResult();
        }
    }
}