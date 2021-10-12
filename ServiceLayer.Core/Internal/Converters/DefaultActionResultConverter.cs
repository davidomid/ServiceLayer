using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Converters;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class DefaultActionResultConverter : 
        IActionResultConverter<IResult>, 
        IActionResultConverter<IResult<HttpStatusCode>>,
        IActionResultConverter<IResult<HttpStatusCode, object>>,
        IActionResultConverter<IDataResult<object>>,
        IActionResultConverter<IDataResult<object, HttpStatusCode>>,
        IActionResultConverter<IDataResult<object, HttpStatusCode, object>>
    {
        public ActionResult Convert(IResult result)
        {
            if (result.IsSuccessful)
            {
                return new OkResult();
            }
            return CreateErrorObjectResult(result, HttpStatusCode.InternalServerError);
        }

        public ActionResult Convert(IResult<HttpStatusCode> result)
        {
            switch (result.ResultType)
            {
                case HttpStatusCode.OK:
                    return new OkResult();
                case HttpStatusCode.BadRequest:
                    return new BadRequestResult();
                case HttpStatusCode.NotFound:
                    return new NotFoundResult();
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedResult();
                case HttpStatusCode.Forbidden:
                    return new ForbidResult();
                case HttpStatusCode.Conflict:
                    return new ConflictResult();
                default:
                    return new StatusCodeResult((int)result.ResultType);
            }
        }

        public ActionResult Convert(IResult<HttpStatusCode, object> result)
        {
            switch (result.ResultType)
            {
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(result.ErrorDetails);
                case HttpStatusCode.Conflict:
                    return CreateErrorObjectResult(result, HttpStatusCode.Conflict);
                case HttpStatusCode.InternalServerError:
                    return CreateErrorObjectResult(result, HttpStatusCode.InternalServerError);
                default:
                    return Convert((IResult<HttpStatusCode>)result);
            }
        }

        public ActionResult Convert(IDataResult<object> result)
        {
            return Convert(new DataResult<object, HttpStatusCode>(result.Data, result.ResultType.ToResultType<HttpStatusCode>())); 
        }

        public ActionResult Convert(IDataResult<object, HttpStatusCode> result)
        {
            switch (result.ResultType)
            {
                case HttpStatusCode.OK:
                    return CreateOkObjectResult(result);
                default:
                    return Convert((IResult<HttpStatusCode>)result);
            }
        }

        public ActionResult Convert(IDataResult<object, HttpStatusCode, object> result)
        {
            switch (result.ResultType)
            {
                case HttpStatusCode.OK:
                    return CreateOkObjectResult(result);
                default:
                    return Convert((IResult<HttpStatusCode, object>)result);
            }
        }

        private static ObjectResult CreateErrorObjectResult<TErrorType>(TErrorType errorDetails, HttpStatusCode httpStatusCode)
        {
            return new ObjectResult(errorDetails)
            {
                StatusCode = (int?)httpStatusCode
            };
        }

        private static OkObjectResult CreateOkObjectResult<TData>(IDataResult<TData> result)
        {
            return new OkObjectResult(result.Data);
        }
    }
}
