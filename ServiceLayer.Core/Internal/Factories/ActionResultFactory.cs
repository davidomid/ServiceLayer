using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Converters;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        private readonly DefaultActionResultTypeConverter _defaultActionResultTypeConverter = new DefaultActionResultTypeConverter();

        public ActionResult Create(IResult result)
        {
            // 1. See if there's a converter for converting the result object to ActionResult. If not one, revert to using the default converter.

            // 2. Once inside the default converter, attempt to convert the result to one with HttpStatusCode ResultType and then trying to
            // convert it again. 

            // 3. There would be a default converter for converting from HttpStatusCode to ActionResult. 

            // See if there's a converter for converting IResult to ActionResult. If not one, revert to converting to HttpStatusCode and then trying to
            // convert to ActionResult using the default logic?
            // Allow someone to specify a converter for converting from the result to an ActionResult? 
            // Allow someone to specify a converter from HttpStatusCode to ActionResult instead of the default logic?

            // Convert to an ActionResult using the default converter. 
            return _defaultActionResultTypeConverter.Convert(result);
        }

        public ActionResult Create<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum
        {
            return _defaultActionResultTypeConverter.Convert(new Result<HttpStatusCode>(result.ResultType.ToResultType<HttpStatusCode>())); 
        }

        public ActionResult Create<TResultType, TErrorType>(IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return _defaultActionResultTypeConverter.Convert(new Result<HttpStatusCode, object>(result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
        }

        public ActionResult Create<TData>(IDataResult<TData> result)
        {
            return _defaultActionResultTypeConverter.Convert(new DataResult<object>(result.Data, result.ResultType));
        }
        
        public ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return _defaultActionResultTypeConverter.Convert(new DataResult<object, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>()));
        }

        public ActionResult Create<TData, TResultType, TErrorType>(IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            return _defaultActionResultTypeConverter.Convert(new DataResult<object, HttpStatusCode, object>(result.Data, result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
        }
    }
}
