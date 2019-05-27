using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public class HttpServiceResult<TData> : DataServiceResult<TData, HttpServiceResultTypes>
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public HttpServiceResult(HttpServiceResultTypes resultType, TData data) : base(data, resultType)
        {
        }

        public HttpServiceResult(HttpServiceResultTypes resultType, TData data, params object[] errorDetails) : base(data, resultType, errorDetails)
        {
        }

        public static implicit operator ActionResult(HttpServiceResult<TData> httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult);
        }
    }
}
