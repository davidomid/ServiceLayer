using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public static class ControllerBaseExtensions
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult serviceResult)
        {
            return ActionResultFactory.Create(serviceResult); 
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData> serviceResult)
        {
            return ActionResultFactory.Create(serviceResult);
        }

        public static ActionResult FromServiceResult<TData>(this ControllerBase controller, IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }

        public static ActionResult FromServiceResult(this ControllerBase controller, IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult); 
        }
    }
}