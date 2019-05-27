using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        public ActionResult Create(IServiceResult serviceResult)
        {
            if (serviceResult.IsSuccessful)
            {
                return new Microsoft.AspNetCore.Mvc.OkResult();
            }
            return this.CreateErrorObjectResult(serviceResult, 500);
        }

        public ActionResult Create(IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return new Microsoft.AspNetCore.Mvc.OkResult();
                case HttpServiceResultTypes.NotFound:
                    return new Microsoft.AspNetCore.Mvc.NotFoundResult();
                case HttpServiceResultTypes.Unauthorized:
                    return new UnauthorizedResult();
                case HttpServiceResultTypes.Forbidden:
                    return new ForbidResult();
                case HttpServiceResultTypes.BadRequest:
                    return new BadRequestObjectResult(httpServiceResult.ErrorDetails);
                case HttpServiceResultTypes.Conflict:
                    return CreateErrorObjectResult(httpServiceResult, 409);
                case HttpServiceResultTypes.InternalServerError:
                    return CreateErrorObjectResult(httpServiceResult, 500); 
                default:
                    goto case HttpServiceResultTypes.InternalServerError;
            }
        }

        public ActionResult Create<TData>(IDataServiceResult<TData> serviceResult)
        {
            if (serviceResult.IsSuccessful)
            {
                return CreateOkObjectResult(serviceResult);
            }

            return this.CreateErrorObjectResult(serviceResult, 500); 
        }

        public ActionResult Create<TData>(IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpServiceResultTypes.Ok:
                    return CreateOkObjectResult(httpServiceResult); 
                default:
                    return this.Create((IServiceResult<HttpServiceResultTypes>)httpServiceResult);
            }
        }

        private OkObjectResult CreateOkObjectResult<TData>(IDataServiceResult<TData> serviceResult)
        {
            return new OkObjectResult(serviceResult.Data);
        }

        private ObjectResult CreateErrorObjectResult(IServiceResult serviceResult, int httpStatusCode)
        {
            return new ObjectResult(serviceResult.ErrorDetails)
            {
                StatusCode = httpStatusCode
            };
        }
    }
}
