using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IActionResultConverter<TResult> : IActionResultConverter where TResult : IResult
    {
        ActionResult Convert(TResult result);
    }
}
