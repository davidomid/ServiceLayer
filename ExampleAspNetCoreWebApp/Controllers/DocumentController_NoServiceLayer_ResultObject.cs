using ExampleServices.NoServiceLayer.ResultObject;
using Microsoft.AspNetCore.Mvc;
using Document = ExampleServices.NoServiceLayer.ResultObject.Document;
using IDocumentStorageService = ExampleServices.NoServiceLayer.ResultObject.IDocumentStorageService;
namespace ExampleAspNetCoreWebApp.Controllers
{
    [Route("api/document_noservicelayer_resultobject")]
    [ApiController]
    public class DocumentController_NoServiceLayer_ResultObject : Controller
    {
        private readonly IDocumentStorageService _documentStorageService;

        public DocumentController_NoServiceLayer_ResultObject(IDocumentStorageService documentStorageService)
        {
            _documentStorageService = documentStorageService;
        }

        [HttpGet]
        public ActionResult<Document> Get(string documentPath, string accessToken)
        {
            GetDocumentResult result = _documentStorageService.GetDocument(documentPath, accessToken);
            return ConvertToActionResult(result);
        }

        private ActionResult ConvertToActionResult(GetDocumentResult getDocumentResult)
        {
            switch (getDocumentResult.ResultType)
            {
                case DocumentStorageResultType.FileNotFound:
                    return NotFound();
                case DocumentStorageResultType.ValidationError:
                    return BadRequest(getDocumentResult.ErrorMessage);
                case DocumentStorageResultType.InvalidAccessToken:
                    return Forbid();
                case DocumentStorageResultType.UnexpectedError:
                    return StatusCode(500, getDocumentResult.ErrorMessage);
                default:
                    return Ok(getDocumentResult.Document);
            }
        }
    }
}
