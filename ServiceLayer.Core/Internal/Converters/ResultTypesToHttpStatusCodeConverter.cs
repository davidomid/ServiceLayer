using System.Net;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class ResultTypesToHttpStatusCodeConverter : OneToOneResultTypeConverter<ResultType, HttpStatusCode>
    {
        public override HttpStatusCode? Convert(ResultType sourceResultType)
        {
            return sourceResultType == ResultType.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
