[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/davidomid/ServiceLayer/Operator-improvements/LICENSE)

# What is this? 

ServiceLayer is a powerful C# library for developing SOLID services with consistent error handling. 

## ServiceLayer lets you write code like this

```csharp
public DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath, string accessToken)
{
    if (documentPath == null)
    {
        return this.Result(DocumentStorageResultType.ValidationError, "Document path is required.");
    }

    if (accessToken == null)
    {
        return this.Result(DocumentStorageResultType.ValidationError, "Access token is required.");
    }

    if (!_authService.IsAccessTokenValid(accessToken))
    {
        return DocumentStorageResultType.InvalidAccessToken;
    }
    if (!File.Exists(documentPath)) {return DocumentStorageResultType.FileNotFound;}
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
```

*Like what you see?* Check out the [wiki](https://github.com/davidomid/ServiceLayer/wiki) for background information, documentation and usage examples.

# Latest Release

|     Package    |    Version   |    Downloads   |
| ------- | ----- | ----- |
| `ServiceLayer` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) |
| `ServiceLayer.Core` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core)


