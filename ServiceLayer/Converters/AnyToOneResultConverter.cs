using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class AnyToOneResultConverter<TDestinationResultType> : ResultTypeConverter, IAnyToOneResultConverter<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        protected AnyToOneResultConverter() : base(null, typeof(TDestinationResultType))
        {
        }

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType);
        }

        public abstract TDestinationResultType Convert(Enum sourceResultType);
    }
}
