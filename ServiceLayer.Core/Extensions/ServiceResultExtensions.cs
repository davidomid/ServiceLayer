using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core.Extensions
{
    public static class ServiceResultExtensions
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public static ActionResult ToActionResult<TData, TResultType>(IDataServiceResult<TData, TResultType> dataServiceResult) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(dataServiceResult);
        }

        public static ActionResult ToActionResult<TData>(IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }

    }
}
