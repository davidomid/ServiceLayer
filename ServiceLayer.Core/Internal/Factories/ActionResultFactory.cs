using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core.Internal.Factories
{
    internal class ActionResultFactory : IActionResultFactory
    {
        static ActionResultFactory()
        {
            ServiceLayerConfiguration.ResultTypeConverters.AddOrReplace(new ServiceResultTypeToHttpStatusCodeConverter());
        }

        public ActionResult Create(IServiceResult serviceResult)
        {
            if (serviceResult.IsSuccessful)
            {
                return new OkResult();
            }
            return CreateErrorObjectResult(serviceResult, HttpStatusCode.InternalServerError);
        }

        public ActionResult Create(IServiceResult<HttpStatusCode> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
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
                    return new BadRequestObjectResult(httpServiceResult.ErrorDetails);
                case HttpStatusCode.Conflict:
                    return CreateErrorObjectResult(httpServiceResult, HttpStatusCode.Conflict);
                case HttpStatusCode.InternalServerError:
                    return CreateErrorObjectResult(httpServiceResult, HttpStatusCode.InternalServerError); 
                default:
                    goto case HttpStatusCode.InternalServerError;
            }
        }

        public ActionResult Create<TResultType>(IServiceResult<TResultType> serviceResult) where TResultType : struct, Enum
        {
            return Create(new ServiceResult<HttpStatusCode>(serviceResult.ResultType.ToResultType<HttpStatusCode>(),
                serviceResult.ErrorDetails));
        }

        public ActionResult Create<TData>(IDataServiceResult<TData> serviceResult)
        {
            return Create(new DataServiceResult<TData, HttpStatusCode>(serviceResult.Data, serviceResult.ResultType.ToResultType<HttpStatusCode>(), serviceResult.ErrorDetails));
        }

        public ActionResult Create<TData, TResultType>(IDataServiceResult<TData, TResultType> serviceResult) where TResultType : struct, Enum
        {
            return Create(new DataServiceResult<TData, HttpStatusCode>(serviceResult.Data, serviceResult.ResultType.ToResultType<HttpStatusCode>(), serviceResult.ErrorDetails));
        }

        public ActionResult Create<TData>(IDataServiceResult<TData, HttpStatusCode> httpServiceResult)
        {
            switch (httpServiceResult.ResultType)
            {
                case HttpStatusCode.OK:
                    return CreateOkObjectResult(httpServiceResult); 
                default:
                    return Create((IServiceResult<HttpStatusCode>)httpServiceResult);
            }
        }

        private OkObjectResult CreateOkObjectResult<TData>(IDataServiceResult<TData> serviceResult)
        {
            return new OkObjectResult(serviceResult.Data);
        }

        private ObjectResult CreateErrorObjectResult(IServiceResult serviceResult, HttpStatusCode httpStatusCode)
        {
            return new ObjectResult(serviceResult.ErrorDetails)
            {
                StatusCode = (int?) httpStatusCode
            };
        }
    }
}
