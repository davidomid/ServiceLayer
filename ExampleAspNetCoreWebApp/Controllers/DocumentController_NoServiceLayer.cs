using System;
using ExampleServices.NoServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Document = ExampleServices.NoServiceLayer.Document;
using IDocumentStorageService = ExampleServices.NoServiceLayer.IDocumentStorageService;
namespace ExampleAspNetCoreWebApp.Controllers
{
    [Route("api/document_noservicelayer")]
    [ApiController]
    public class DocumentController_NoServiceLayer : Controller
    {
        private readonly IDocumentStorageService _documentStorageService;

        public DocumentController_NoServiceLayer(IDocumentStorageService documentStorageService)
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
                return BadRequest(validationException.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An unexpected error occurred while retrieving the document.");
            }
        }
    }
}
