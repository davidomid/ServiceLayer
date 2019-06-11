using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal interface IActionResultFactory
    {
        ActionResult Create(IServiceResult serviceResult);
        ActionResult Create<TResultType>(IServiceResult<TResultType> serviceResult) where TResultType : struct, Enum;
        ActionResult Create(IServiceResult<HttpStatusCode> httpServiceResult);
        ActionResult Create<TData>(IDataServiceResult<TData> serviceResult);
        ActionResult Create<TData, TResultType>(IDataServiceResult<TData, TResultType> serviceResult)
            where TResultType : struct, Enum;
        ActionResult Create<TData>(IDataServiceResult<TData, HttpStatusCode> httpServiceResult);
    }
}
