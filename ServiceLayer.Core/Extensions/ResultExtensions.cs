using System;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this IResult result)
        {
            return GetActionResultFactory().Create(result);
        }

        public static ActionResult ToActionResult<TResultType>(this IResult<TResultType> result) where TResultType : struct, Enum
        {
            return GetActionResultFactory().Create(result);
        }

        public static ActionResult ToActionResult<TResultType, TErrorType>(this IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return GetActionResultFactory().Create(result);
        }

        public static ActionResult ToActionResult<TData>(this IDataResult<TData> dataResult)
        {
            return GetActionResultFactory().Create(dataResult);
        }

        public static ActionResult ToActionResult<TData, TResultType>(this IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return GetActionResultFactory().Create(result);
        }

        public static ActionResult ToActionResult<TData, TResultType, TErrorType>(this IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return GetActionResultFactory().Create(result);
        }

        private static IActionResultFactory GetActionResultFactory()
        {
            var actionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();
            if (actionResultFactory == null)
            {
                throw new Exception("ServiceLayer.Core encountered an error whilst attempting to create an ActionResult. Please make sure the ServiceLayer AspNetCorePlugin has been initialised and installed correctly.");
            }

            return actionResultFactory;
        }
    }
}
