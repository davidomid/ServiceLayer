using System.Net;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class HttpStatusCodeToResultTypesConverter : OneToOneResultTypeConverter<HttpStatusCode, ResultType>
    {
        public override ResultType? Convert(HttpStatusCode sourceResultType)
        {
            int statusCode = (int) sourceResultType;
            if (statusCode >= 200 && statusCode <= 299)
            {
                return ResultType.Success;
            }
            if (statusCode >= 400 && statusCode <= 599)
            {
                return ResultType.Failure;
            }
            return ResultType.Inconclusive;
        }
    }
}
