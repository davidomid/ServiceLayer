using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;
using ServiceLayer;

namespace ExampleServices
{
    public interface IDocumentStorageService : IService
    {
         DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath, string accessToken);
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

            if (accessToken == null) return "Access token is required.";
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

    public interface IAuthService
    {
        bool IsAccessTokenValid();
    }

    public enum DocumentStorageResultType
    {
        [Failure]
        UnexpectedError,
        [Success]
        FileRetrievalSuccessful,
        FileNotFound,
        InvalidAccessToken,
        ValidationError
    }
}
