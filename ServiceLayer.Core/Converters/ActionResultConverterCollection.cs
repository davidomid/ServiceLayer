using System.Collections.Generic;
using System.Linq;
using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public sealed class ActionResultConverterCollection
    {
        private readonly List<IActionResultConverter> _actionResultConverters;
        public ActionResultConverterCollection(List<IActionResultConverter> actionResultConverters)
        {
            _actionResultConverters = new List<IActionResultConverter>(actionResultConverters)
            {
                new DefaultActionResultConverter()
            };
        }

        internal IActionResultConverter<TResult> GetActionResultConverter<TResult>() where TResult : IResult
        {
            var actionResultConverter = _actionResultConverters.OfType<IActionResultConverter<TResult>>().FirstOrDefault();
            return actionResultConverter;
        }
    }
}
