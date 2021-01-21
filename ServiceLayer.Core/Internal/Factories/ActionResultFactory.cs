using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Converters;
using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        private readonly IActionResultConverterCollection _actionResultConverters = new ActionResultConverterCollection();

        public ActionResult Create(IResult result)
        {
            IActionResultConverter<IResult> actionResultConverter = GetActionResultConverter<IResult>();
            return actionResultConverter.Convert(result);
        }

        public ActionResult Create<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum
        {
            IActionResultConverter<IResult<TResultType>> actionResultConverter = GetActionResultConverter<IResult<TResultType>>();
            if (actionResultConverter == null)
            {
                return Create(new Result<HttpStatusCode>(result.ResultType.ToResultType<HttpStatusCode>()));
            }
            return actionResultConverter.Convert(result);
        }

        public ActionResult Create<TResultType, TErrorType>(IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            IActionResultConverter<IResult<TResultType, TErrorType>> actionResultConverter = GetActionResultConverter<IResult<TResultType, TErrorType>>();
            if (actionResultConverter == null)
            {
                return Create(new Result<HttpStatusCode, object>(result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
            }
            return actionResultConverter.Convert(result);
        }

        public ActionResult Create<TData>(IDataResult<TData> result)
        {
            IActionResultConverter<IDataResult<TData>> actionResultConverter = GetActionResultConverter<IDataResult<TData>>();
            if (actionResultConverter == null)
            {
                return Create<object>(new DataResult<object>(result.Data, result.ResultType));
            }
            return actionResultConverter.Convert(result);
        }
        
        public ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            IActionResultConverter<IDataResult<TData, TResultType>> actionResultConverter = GetActionResultConverter<IDataResult<TData, TResultType>>();
            if (actionResultConverter == null)
            {
                return Create(new DataResult<object, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>()));
            }
            return actionResultConverter.Convert(result);
        }

        public ActionResult Create<TData, TResultType, TErrorType>(IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            IActionResultConverter<IDataResult<TData, TResultType, TErrorType>> actionResultConverter = GetActionResultConverter<IDataResult<TData, TResultType, TErrorType>>();
            if (actionResultConverter == null)
            {
                return Create(new DataResult<object, HttpStatusCode, object>(result.Data, result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
            }
            return actionResultConverter.Convert(result);
        }

        private IActionResultConverter<TResult> GetActionResultConverter<TResult>() where TResult : IResult
        {
            if (_actionResultConverters.Installed.TryGetValue(typeof(TResult), out var actionResultConverter))
            {
                return (IActionResultConverter<TResult>) actionResultConverter;
            }
            return null;
        }
    }
}
