using System.Net;
using ServiceLayer;

namespace ExampleServices
{
    public class DocumentResultTypeHttpConverter : OneToOneResultTypeConverter<DocumentStorageResultType, HttpStatusCode>
    {
        public override HttpStatusCode? Convert(DocumentStorageResultType sourceResultType)
        {
            switch (sourceResultType)
            {
                case DocumentStorageResultType.FileNotFound: return HttpStatusCode.NotFound;
                case DocumentStorageResultType.InvalidAccessToken: return HttpStatusCode.Forbidden;
                case DocumentStorageResultType.ValidationError: return HttpStatusCode.BadRequest;
            }

            return null;
        }
    }
}
