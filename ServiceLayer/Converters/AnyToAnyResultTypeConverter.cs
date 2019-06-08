using System;

namespace ServiceLayer.Converters
{
    public abstract class AnyToAnyResultTypeConverter : ResultTypeConverter
    {
        protected AnyToAnyResultTypeConverter() : base(null, null)
        {
        }

        internal abstract override Enum Convert(Enum sourceResultType, Type destinationEnumType);
    }
}
