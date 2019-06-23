using System.Net;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class ResultTypesToHttpStatusCodeConverter : OneToOneResultTypeConverter<ResultTypes, HttpStatusCode>
    {
        public override HttpStatusCode? Convert(ResultTypes sourceResultType)
        {
            return sourceResultType == ResultTypes.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
