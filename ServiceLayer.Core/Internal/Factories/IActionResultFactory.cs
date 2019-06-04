using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal interface IActionResultFactory
    {
        ActionResult Create(IServiceResult serviceResult);
        ActionResult Create(IServiceResult<HttpServiceResultTypes> httpServiceResult);
        ActionResult Create<TData>(IDataServiceResult<TData> serviceResult);
        ActionResult Create<TData>(IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult);
    }
}
