using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core.Extensions
{
    public static class ServiceResultExtensions
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public static ActionResult ToActionResult(this IServiceResult serviceResult)
        {
            return ActionResultFactory.Create(serviceResult);
        }

        public static ActionResult ToActionResult<TData>(this IDataServiceResult<TData> dataServiceResult)
        {
            return ActionResultFactory.Create(dataServiceResult);
        }

        public static ActionResult ToActionResult<TData>(this IDataServiceResult<TData, HttpServiceResultTypes> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }

        public static ActionResult ToActionResult(this IServiceResult<HttpServiceResultTypes> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }
    }
}
