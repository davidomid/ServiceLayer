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
        FileRetrievalSuccessful,
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

        public DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath,
            string accessToken)
        {
            if (documentPath == null) return this.Result(DocumentStorageResultType.ValidationError, "Document path is required.");
            if (accessToken == null) return this.Result(DocumentStorageResultType.ValidationError, "Access token is required.");

            if (!_authService.IsAccessTokenValid()) return DocumentStorageResultType.InvalidAccessToken;

            if (!File.Exists(documentPath)) return DocumentStorageResultType.FileNotFound;

            string json = File.ReadAllText(documentPath);
            Document document = JsonConvert.DeserializeObject<Document>(json);
            return document;
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
}
