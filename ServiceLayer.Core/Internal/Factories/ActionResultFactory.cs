using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        public ActionResult Create(IResult result)
        {
            if (result.IsSuccessful)
            {
                return new OkResult();
            }
            return CreateErrorObjectResult(result, HttpStatusCode.InternalServerError);
        }

        public ActionResult Create(IResult<HttpStatusCode> httpResult)
        {
            switch (httpResult.ResultType)
            {
                case HttpStatusCode.OK:
                    return new OkResult();
                case HttpStatusCode.NotFound:
                    return new NotFoundResult();
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedResult();
                case HttpStatusCode.Forbidden:
                    return new ForbidResult();
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(httpResult.ErrorDetails);
                case HttpStatusCode.Conflict:
                    return CreateErrorObjectResult(httpResult, HttpStatusCode.Conflict);
                case HttpStatusCode.InternalServerError:
                    return CreateErrorObjectResult(httpResult, HttpStatusCode.InternalServerError); 
                default:
                    goto case HttpStatusCode.InternalServerError;
            }
        }

        public ActionResult Create<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum
        {
            return Create(new Result<HttpStatusCode>(result.ResultType.ToResultType<HttpStatusCode>(),
                result.ErrorDetails));
        }

        public ActionResult Create<TData>(IDataResult<TData> result)
        {
            return Create(new DataResult<TData, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
        }

        public ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            return Create(new DataResult<TData, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
        }

        public ActionResult Create<TData>(IDataResult<TData, HttpStatusCode> httpResult)
        {
            switch (httpResult.ResultType)
            {
                case HttpStatusCode.OK:
                    return CreateOkObjectResult(httpResult); 
                default:
                    return Create((IResult<HttpStatusCode>)httpResult);
            }
        }

        private OkObjectResult CreateOkObjectResult<TData>(IDataResult<TData> result)
        {
            return new OkObjectResult(result.Data);
        }

        private ObjectResult CreateErrorObjectResult(IResult result, HttpStatusCode httpStatusCode)
        {
            return new ObjectResult(result.ErrorDetails)
            {
                StatusCode = (int?) httpStatusCode
            };
        }
    }
}
