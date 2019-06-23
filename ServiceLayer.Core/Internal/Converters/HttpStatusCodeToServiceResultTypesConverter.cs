using System.Net;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class HttpStatusCodeToServiceResultTypesConverter : OneToOneResultTypeConverter<HttpStatusCode, ResultTypes>
    {
        public override ResultTypes? Convert(HttpStatusCode sourceResultType)
        {
            int statusCode = (int) sourceResultType;
            if (statusCode >= 200 && statusCode <= 299)
            {
                return ResultTypes.Success;
            }
            if (statusCode >= 400 && statusCode <= 599)
            {
                return ResultTypes.Failure;
            }
            return ResultTypes.Inconclusive;
        }
    }
}
