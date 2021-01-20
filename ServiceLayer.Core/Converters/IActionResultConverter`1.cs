using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    public interface IActionResultConverter<in TResult> : IActionResultConverter where TResult : IResult
    {
        ActionResult Convert(TResult result);
    }
}
