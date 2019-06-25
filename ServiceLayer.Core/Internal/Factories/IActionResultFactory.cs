using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal interface IActionResultFactory
    {
        ActionResult Create(IResult result);
        ActionResult Create<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum;
        ActionResult Create(IResult<HttpStatusCode> httpResult);
        ActionResult Create<TData>(IDataResult<TData> result);
        ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result)
            where TResultType : struct, Enum;
        ActionResult Create<TData>(IDataResult<TData, HttpStatusCode> httpResult);
    }
}
