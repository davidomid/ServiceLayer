﻿using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ServiceResultExtensions
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public static ActionResult ToActionResult(this IServiceResult serviceResult)
        {
            return ActionResultFactory.Create(serviceResult);
        }

        public static ActionResult ToActionResult<TResultType>(this IServiceResult<TResultType> serviceResult) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(serviceResult);
        }

        public static ActionResult ToActionResult<TData>(this IDataServiceResult<TData> dataServiceResult)
        {
            return ActionResultFactory.Create(dataServiceResult);
        }

        public static ActionResult ToActionResult<TData, TResultType>(this IDataServiceResult<TData, TResultType> serviceResult) where TResultType : struct, Enum
        {
            return ActionResultFactory.Create(serviceResult);
        }

        public static ActionResult ToActionResult<TData>(this IDataServiceResult<TData, HttpStatusCode> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }
    }
}
