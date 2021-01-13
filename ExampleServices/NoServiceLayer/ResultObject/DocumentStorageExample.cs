using System;
using System.IO;
using Newtonsoft.Json;

namespace ExampleServices.NoServiceLayer.ResultObject
{
    public interface IDocumentStorageService
    {
        GetDocumentResult GetDocument(string documentPath, string accessToken);
    }

    public class DocumentStorageService : IDocumentStorageService
    {
        private readonly IAuthService _authService;

        public DocumentStorageService(IAuthService authService)
        {
            _authService = authService;
        }

        public GetDocumentResult GetDocument(string documentPath, string accessToken)
        {
            if (documentPath == null) return new GetDocumentResult(DocumentStorageResultType.ValidationError, null, "Document path is required.");
            if (accessToken == null) return new GetDocumentResult(DocumentStorageResultType.ValidationError, null, "Access token is required.");
            if (!_authService.IsAccessTokenValid(accessToken)) return new GetDocumentResult(DocumentStorageResultType.InvalidAccessToken);
            if (!File.Exists(documentPath)) return new GetDocumentResult(DocumentStorageResultType.FileNotFound);
            try
            {
                string json = File.ReadAllText(documentPath);
                Document document = JsonConvert.DeserializeObject<Document>(json);
                return new GetDocumentResult(DocumentStorageResultType.Successful, document);
            }
            catch (Exception)
            {
                return new GetDocumentResult(DocumentStorageResultType.UnexpectedError, null,
                    "An unexpected error occurred while retrieving the document.");
            }
        }
    }

    public class GetDocumentResult
    {
        public Document Document { get; set; }
        public DocumentStorageResultType ResultType { get; set; }
        public string ErrorMessage { get; set; }

        public GetDocumentResult(DocumentStorageResultType resultType, Document document = null, string errorMessage = null)
        {
            ResultType = resultType;
            Document = document;
            ErrorMessage = errorMessage;
        }
    }

    public enum DocumentStorageResultType
    {
        UnexpectedError,
        Successful,
        FileNotFound,
        InvalidAccessToken,
        ValidationError
    }

    public class Document
    {
    }

    public interface IAuthService
    {
        bool IsAccessTokenValid(string accessToken);
    }
}
