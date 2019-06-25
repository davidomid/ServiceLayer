[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://raw.githubusercontent.com/davidomid/ServiceLayer/Operator-improvements/LICENSE)

# ServiceLayer
A C# library for developing SOLID services with consistent error handling. 

## What can this library do for me? 

This library can dramatically simplify your error handling logic across your projects and allow you to write code in a truly SOLID way.

It alleviates considerable problems which may developers face when writing logic for services and their consumers such as:

- Accidentally couping your service logic to your hosting logic, like this [insert link here].
- Having to create lots of custom exception classes, like this [insert link here to example].
- Implementing a lot of ugly try-catch blocks for handling various exception types, like this [insert link here].
- Needing to create lot of custom "result" classes which wrap some form of result type, error details and data, like this [insert link here].
- Possible ambiguity between success and failure, like this [insert link here].
- Requiring knowledge of the internal workings of a concrete implementation of services you're consuming, like this [insert link here].

### "Before" and "After" using ServiceLayer

#### Your API Controller
##### Before
```csharp
[HttpGet]
public ActionResult<Document> Get(string documentPath, string accessToken)
{
    try
    {
        Document document = _documentStorageService.GetDocument(documentPath, accessToken);
        if (document == null)
        {
            return NotFound();
        }

        return Ok(document);
    }
    catch (ValidationException validationException)
    {
        return BadRequest(validationException.ValidationResult.ErrorMessage);
    }
    catch (InvalidAccessTokenException)
    {
        return Forbid();
    }
    catch (Exception)
    {
        return StatusCode(500, "An unexpected error occurred while retrieving the document.");
    }
}
```
##### After
```csharp
[HttpGet]
public ActionResult<Document> Get(string documentPath, string accessToken)
{
    return _documentStorageService.GetDocument(documentPath, accessToken).ToActionResult();
}
```

#### Your service
##### Before
```csharp
public Document GetDocument(string documentPath, string accessToken)
{
    if (documentPath == null) throw new ValidationException("Document path is required.");
    if (accessToken == null) throw new ValidationException("Access token is required.");
    if (!_authService.IsAccessTokenValid()) throw new InvalidAccessTokenException();
    if (!File.Exists(documentPath)) return null;
    string json = File.ReadAllText(documentPath);
    Document document = JsonConvert.DeserializeObject<Document>(json);
    return document;
}
```
##### After
```csharp
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
    catch (Exception exception)
    {
        return "An unexpected error occurred while retrieving the document."; 
    }
}
```

## Installation

ServiceLayer is available as a NuGet package: 

```
Install-Package ServiceLayer
```

### ASP.NET Core integration

Some useful features for integrating ServiceLayer with ASP.NET Core applications is also available as a separate NuGet package: 

```
Install-Package ServiceLayer.Core
```


|     Package    |    Version   |    Downloads   |
| ------- | ----- | ----- |
| `ServiceLayer` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.svg)](https://nuget.org/packages/ServiceLayer) |
| `ServiceLayer.Core` | [![NuGet](https://img.shields.io/nuget/v/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core) | [![Nuget](https://img.shields.io/nuget/dt/ServiceLayer.Core.svg)](https://nuget.org/packages/ServiceLayer.Core)


