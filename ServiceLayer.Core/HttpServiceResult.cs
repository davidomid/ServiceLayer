using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Factories;

namespace ServiceLayer.Core
{
    public class HttpServiceResult : ServiceResult<HttpServiceResultTypes>
    {
        internal static IActionResultFactory ActionResultFactory = ServiceLocator.Instance.Resolve<IActionResultFactory>();

        public HttpServiceResult(HttpServiceResultTypes resultType) : this(resultType, default)
        {
        }

        public HttpServiceResult(HttpServiceResultTypes resultType, params object[] errorDetails) : this(resultType, (object)errorDetails)
        {
        }

        public HttpServiceResult(HttpServiceResultTypes resultType, object errorDetails) : base(resultType, errorDetails)
        {
        }

        public static implicit operator ActionResult(HttpServiceResult httpServiceResult)
        {
            return ActionResultFactory.Create(httpServiceResult); 
        }
    }
}
