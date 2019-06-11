using System.Net;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class HttpStatusCodeToServiceResultTypesConverter : OneToOneResultTypeConverter<HttpStatusCode, ServiceResultTypes>
    {
        public override ServiceResultTypes? Convert(HttpStatusCode sourceResultType)
        {
            int statusCode = (int) sourceResultType;
            if (statusCode >= 200 && statusCode <= 299)
            {
                return ServiceResultTypes.Success;
            }
            return ServiceResultTypes.Failure;
        }
    }
}
