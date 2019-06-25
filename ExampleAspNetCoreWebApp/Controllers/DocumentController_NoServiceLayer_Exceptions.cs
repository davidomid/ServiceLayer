using System;
using System.ComponentModel.DataAnnotations;
using ExampleServices.NoServiceLayer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Document = ExampleServices.NoServiceLayer.Exceptions.Document;
using IDocumentStorageService = ExampleServices.NoServiceLayer.Exceptions.IDocumentStorageService;
namespace ExampleAspNetCoreWebApp.Controllers
{
    [Route("api/document_noservicelayer_exception")]
    [ApiController]
    public class DocumentController_NoServiceLayer_Exceptions : Controller
    {
        private readonly IDocumentStorageService _documentStorageService;

        public DocumentController_NoServiceLayer_Exceptions(IDocumentStorageService documentStorageService)
        {
            _documentStorageService = documentStorageService;
        }

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
    }
}
