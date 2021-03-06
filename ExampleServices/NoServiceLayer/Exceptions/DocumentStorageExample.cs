﻿using System;
using System.IO;
using Newtonsoft.Json;

namespace ExampleServices.NoServiceLayer.Exceptions
{
    public interface IDocumentStorageService
    {
        Document GetDocument(string documentPath, string accessToken);
    }

    public class DocumentStorageService : IDocumentStorageService
    {
        private readonly IAuthService _authService;

        public DocumentStorageService(IAuthService authService)
        {
            _authService = authService;
        }

        public Document GetDocument(string documentPath, string accessToken)
        {
            if (documentPath == null) throw new ValidationException("Document path is required.");
            if (accessToken == null) throw new ValidationException("Access token is required.");

            if (!_authService.IsAccessTokenValid(accessToken)) throw new InvalidAccessTokenException();

            if (!File.Exists(documentPath)) return null;

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
        bool IsAccessTokenValid(string accessToken);
    }

    public class InvalidAccessTokenException : Exception
    {
    }

    public class ValidationException : Exception
    {
        public ValidationException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
