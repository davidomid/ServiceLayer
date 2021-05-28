using System;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ResultExtensions
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public static ActionResult ToActionResult(this IResult result)
        {
            return ActionResultFactory.Create(result);
        }

        public static ActionResult ToActionResult<TResultType>(this IResult<TResultType> result) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(result);
        }

        public static ActionResult ToActionResult<TResultType, TErrorType>(this IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(result);
        }

        public static ActionResult ToActionResult<TData>(this IDataResult<TData> dataResult)
        {
            return ActionResultFactory.Create(dataResult);
        }

        public static ActionResult ToActionResult<TData, TResultType>(this IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(result);
        }

        public static ActionResult ToActionResult<TData, TResultType, TErrorType>(this IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(result);
        }
    }
}
