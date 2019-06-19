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
            if (statusCode >= 400 && statusCode <= 599)
            {
                return ServiceResultTypes.Failure;
            }
            return ServiceResultTypes.Inconclusive;
        }
    }
}
