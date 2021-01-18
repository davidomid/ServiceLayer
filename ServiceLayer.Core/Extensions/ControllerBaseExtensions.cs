using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromResult(this ControllerBase controller, IResult result)
        {
            return result.ToActionResult();
        }

        public static ActionResult FromResult<TResultType>(this ControllerBase controller, IResult<TResultType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }

        public static ActionResult FromResult<TResultType, TErrorType>(this ControllerBase controller, IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }

        public static ActionResult FromResult<TData>(this ControllerBase controller, IDataResult<TData> result)
        {
            return result.ToActionResult();
        }

        public static ActionResult FromResult<TData, TResultType>(this ControllerBase controller, IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }

        public static ActionResult FromResult<TData, TResultType, TErrorType>(this ControllerBase controller, IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return result.ToActionResult();
        }
    }
}