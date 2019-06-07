using System;
using ServiceLayer.Converters;

namespace ServiceLayer.Core
{
    internal class HttpServiceResultConverter : AnyToOneResultConverter<HttpServiceResultTypes>
    {
        public override HttpServiceResultTypes? Convert(Enum sourceResultType)
        {
            throw new NotImplementedException();
        }
    }
}
