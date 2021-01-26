using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IActionResultConverter<TResult> : IActionResultConverter where TResult : IResult
    {
        ActionResult Convert(TResult result);
    }
}
