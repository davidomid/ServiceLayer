[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/davidomid/ServiceLayer/Operator-improvements/LICENSE)

# What is this? 

ServiceLayer is a powerful C# library for developing SOLID services with consistent error handling. 

## ServiceLayer lets you write code like this

### An example service method...
```csharp
public class DocumentStorageService
{
    public DataResult<Document, DocumentStorageResultType, string> GetDocument(string documentPath)
    {
        if (documentPath == null)
        {
            return this.Result(DocumentStorageResultType.ValidationError, "Document path is required.");
        }

        if (!File.Exists(documentPath)) 
        {
            return DocumentStorageResultType.FileNotFound;
        }

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
```
### An example API action consuming that service...
```csharp
[HttpGet]
public ActionResult<Document> Get(string documentPath)
{
    return documentStorageService.GetDocument(documentPath).ToActionResult();
}
```
### Another example of the method being consumed by an API action...
```csharp
[HttpGet]
public ActionResult<Document> Get(string documentPath)
{
    var documentResult = _documentStorageService.GetDocument(documentPath);
    switch (documentResult.ResultType)
    {
        case DocumentStorageResultType.Successful:
            return documentResult.Data;
        case DocumentStorageResultType.FileNotFound:
            return this.NotFound();
        case DocumentStorageResultType.ValidationError:
            return this.BadRequest(documentResult.ErrorDetails);
        case DocumentStorageResultType.UnexpectedError:
            return this.StatusCode(500, "An unexpected error occurred.");
        default:
            return _documentStorageService.GetDocument(documentPath, accessToken).ToActionResult();
    }
}
```

### Has this piqued your interest? 

Check out the **[wiki](https://github.com/davidomid/ServiceLayer/wiki)** for background information, documentation and usage examples.

# Latest Release

|     Package    |    Version   |    Downloads   |
| ------- | ----- | ----- |
| `ServiceLayer` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) |
| `ServiceLayer.Core` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core)


