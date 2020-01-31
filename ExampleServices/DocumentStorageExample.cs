using System.IO;
using System.Net;
using Newtonsoft.Json;
using ServiceLayer;

namespace ExampleServices
{
    public interface IDocumentStorageService : IService
    {
         DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath, string accessToken);
    }

    public enum DocumentStorageResultType
    {
        [Failure]
        [ResultType(HttpStatusCode.InternalServerError)]
        UnexpectedError,
        [Success]
        [ResultType(HttpStatusCode.OK)]
        Successful,
        FileNotFound,
        InvalidAccessToken,
        ValidationError
    }

    public interface IAuthService
    {
        bool IsAccessTokenValid();
    }

    public class DocumentStorageService : IDocumentStorageService
    {
        private readonly IAuthService _authService;

        public DocumentStorageService(IAuthService authService)
        {
            _authService = authService;
        }

        public DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath, string accessToken)
        {
            if (documentPath == null) return this.Result(DocumentStorageResultType.ValidationError, "Document path is required.");
            if (accessToken == null) return this.Result(DocumentStorageResultType.ValidationError, "Access token is required.");
            if (!_authService.IsAccessTokenValid()) return DocumentStorageResultType.InvalidAccessToken;
            if (!File.Exists(documentPath)) return DocumentStorageResultType.FileNotFound;
            try
            {
                string json = File.ReadAllText(documentPath);
                Document document = JsonConvert.DeserializeObject<Document>(json);
                return document;
            }
            catch
            {
                return "An unexpected error occurred while retrieving the document."; 
            }
        }
    }

    public class Document
    {
    }
    public class AuthService : IAuthService
    {
        public bool IsAccessTokenValid()
        {
            return true;
        }
    }

    public class DocumentServicePlugin : Plugin
    {
        public DocumentServicePlugin() : base("Document Service")
        {
        }

        public override void Install()
        {
            Context.ResultTypeConverters.Install(new DocumentResultTypeHttpConverter());
        }

        private class DocumentResultTypeHttpConverter : OneToOneResultTypeConverter<DocumentStorageResultType, HttpStatusCode>
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

}
