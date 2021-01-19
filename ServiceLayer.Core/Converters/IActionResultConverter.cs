using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    public interface IActionResultConverter
    {
        ActionResult Convert(IResult result);
        ActionResult Convert<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum;
        ActionResult Convert<TResultType, TErrorType>(IResult<TResultType, TErrorType> result) where TResultType : struct, Enum;
        ActionResult Convert<TData>(IDataResult<TData> result);
        ActionResult Convert<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum;
        ActionResult Convert<TData, TResultType, TErrorType>(IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum;
    }
}
