using System.Net;
using ServiceLayer.Converters;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class ServiceResultTypesToHttpStatusCodeConverter : OneToOneResultTypeConverter<ServiceResultTypes, HttpStatusCode>
    {
        public override HttpStatusCode? Convert(ServiceResultTypes sourceResultType)
        {
            return sourceResultType == ServiceResultTypes.Success ? HttpStatusCode.OK : HttpStatusCode.InternalServerError;
        }
    }
}
