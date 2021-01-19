using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    public class DefaultActionResultTypeConverter : IActionResultConverter
    {
        public ActionResult Convert(IResult result)
        {
            if (result.IsSuccessful)
            {
                return new OkResult();
            }
            return CreateErrorObjectResult(result, HttpStatusCode.InternalServerError);
        }
    }
}
