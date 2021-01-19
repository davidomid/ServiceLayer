using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        //public ActionResult Create<TErrorType>(IResult<HttpStatusCode, TErrorType> httpResult)
        //{
        //    switch (httpResult.ResultType)
        //    {
        //        case HttpStatusCode.BadRequest:
        //            return new BadRequestObjectResult(httpResult.ErrorDetails);
        //        case HttpStatusCode.Conflict:
        //            return CreateErrorObjectResult(httpResult, HttpStatusCode.Conflict);
        //        case HttpStatusCode.InternalServerError:
        //            return CreateErrorObjectResult(httpResult, HttpStatusCode.InternalServerError);
        //        default:
        //            return Create((IResult<HttpStatusCode>) httpResult);
        //    }
        //}

        //public ActionResult Create(IResult<HttpStatusCode> httpResult)
        //{
        //    switch (httpResult.ResultType)
        //    {
        //        case HttpStatusCode.OK:
        //            return new OkResult();
        //        case HttpStatusCode.BadRequest:
        //            return new BadRequestResult();
        //        case HttpStatusCode.NotFound:
        //            return new NotFoundResult();
        //        case HttpStatusCode.Unauthorized:
        //            return new UnauthorizedResult();
        //        case HttpStatusCode.Forbidden:
        //            return new ForbidResult();
        //        case HttpStatusCode.Conflict:
        //            return new ConflictResult();
        //        default:
        //            return new StatusCodeResult((int)httpResult.ResultType);
        //    }
        //}

        //public ActionResult Create<TResultType, TErrorType>(IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        //{
        //    return Create(new Result<HttpStatusCode, TErrorType>(result.ResultType.ToResultType<HttpStatusCode>(), result.ErrorDetails));
        //}

        //public ActionResult Create<TData>(IDataResult<TData> result)
        //{
        //    return Create(new DataResult<TData, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>()));
        //}

        //public ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        //{
        //    return Create(new DataResult<TData, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>()));
        //}

        //public ActionResult Create<TData>(IDataResult<TData, HttpStatusCode> httpResult)
        //{
        //    switch (httpResult.ResultType)
        //    {
        //        case HttpStatusCode.OK:
        //            return CreateOkObjectResult(httpResult); 
        //        default:
        //            return Create((IResult<HttpStatusCode>)httpResult);
        //    }
        //}

        //private OkObjectResult CreateOkObjectResult<TData>(IDataResult<TData> result)
        //{
        //    return new OkObjectResult(result.Data);
        //}

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

            if (result.IsSuccessful)
            {
                return new OkResult();
            }
            return CreateErrorObjectResult(result, HttpStatusCode.InternalServerError);
        }

        public ActionResult Create<TResultType>(IResult<TResultType> result) where TResultType : struct, Enum
        {
            throw new NotImplementedException();
        }

        public ActionResult Create<TResultType, TErrorType>(IResult<TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            throw new NotImplementedException();
        }

        public ActionResult Create<TData>(IDataResult<TData> result)
        {
            throw new NotImplementedException();
        }

        public ActionResult Create<TData, TResultType>(IDataResult<TData, TResultType> result) where TResultType : struct, Enum
        {
            throw new NotImplementedException();
        }

        public ActionResult Create<TData, TResultType, TErrorType>(IDataResult<TData, TResultType, TErrorType> result) where TResultType : struct, Enum
        {
            throw new NotImplementedException();
        }

        private ObjectResult CreateErrorObjectResult<TErrorType>(TErrorType errorDetails, HttpStatusCode httpStatusCode)
        {
            return new ObjectResult(errorDetails)
            {
                StatusCode = (int?)httpStatusCode
            };
        }

    }
}
