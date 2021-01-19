using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    public interface IActionResultConverter<in TResult> where TResult : IResult
    {
        ActionResult Convert(TResult result);
    }
}
