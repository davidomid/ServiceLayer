using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core.Converters
{
    public sealed class ActionResultTypeConverter<TResult> : IActionResultConverter<TResult> where TResult : IResult
    {
        private readonly Func<TResult, ActionResult> _function;

        public ActionResultTypeConverter(Func<TResult, ActionResult> function)
        {
            _function = function;
        }

        public ActionResult Convert(TResult result)
        {
            return _function(result);
        }
    }
}
