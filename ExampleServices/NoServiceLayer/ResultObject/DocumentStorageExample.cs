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
            if (documentPath == null)
            {
                return new GetDocumentResult {
                    ResultType = DocumentStorageResultType.ValidationError,
                    ErrorMessage = "Document path is required."
                };
            }

            if (accessToken == null)
            {
                return new GetDocumentResult
                {
                    ResultType = DocumentStorageResultType.ValidationError,
                    ErrorMessage = "Access token is required."
                };
            }

            if (!_authService.IsAccessTokenValid())
            {
                return new GetDocumentResult
                {
                    ResultType = DocumentStorageResultType.InvalidAccessToken
                };
            }

            if (!File.Exists(documentPath))
            {
                return new GetDocumentResult
                {
                    ResultType = DocumentStorageResultType.FileNotFound
                };
            }

            try
            {
                string json = File.ReadAllText(documentPath);
                Document document = JsonConvert.DeserializeObject<Document>(json);
                return new GetDocumentResult
                {
                    Document = document,
                    ResultType = DocumentStorageResultType.Successful
                };
            }
            catch (Exception)
            {
                return new GetDocumentResult
                {
                    ResultType = DocumentStorageResultType.UnexpectedError,
                    ErrorMessage = "An unexpected error occurred while retrieving the document."
                };
            }
        }
    }

    public class GetDocumentResult
    {
        public Document Document { get; set; }
        public DocumentStorageResultType ResultType { get; set; }
        public string ErrorMessage { get; set; }
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
        bool IsAccessTokenValid();
    }
}
