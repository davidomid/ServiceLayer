using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Extensions;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData> serviceResult)
        {
            return serviceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            return httpServiceResult.ToActionResult();
        }

        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            return httpServiceResult.ToActionResult();
        }
    }
}