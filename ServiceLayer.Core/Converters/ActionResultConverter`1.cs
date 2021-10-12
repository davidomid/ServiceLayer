using System;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Core
{
    public sealed class ActionResultConverter<TResult> : IActionResultConverter<TResult> where TResult : IResult
    {
        private readonly Func<TResult, ActionResult> _function;

        public ActionResultConverter(Func<TResult, ActionResult> function)
        {
            _function = function;
        }

        public ActionResult Convert(TResult result)
        {
            return _function(result);
        }
    }
}
