using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Core;
using Document = ExampleServices.Document;
using IDocumentStorageService = ExampleServices.IDocumentStorageService;

namespace ExampleAspNetCoreWebApp.Controllers
{
    [Route("api/document")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentStorageService _documentStorageService;

        public DocumentController(IDocumentStorageService documentStorageService)
        {
            _documentStorageService = documentStorageService;
        }

        [HttpGet]
        public ActionResult<Document> Get(string documentPath, string accessToken)
        {
            return _documentStorageService.GetDocument(documentPath, accessToken).ToActionResult();
        }
    }
}
