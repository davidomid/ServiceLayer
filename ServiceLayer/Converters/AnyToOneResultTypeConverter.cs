using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    public abstract class AnyToOneResultTypeConverter<TDestinationResultType> : ResultTypeConverter, IAnyToOneResultTypeConverter<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        protected AnyToOneResultTypeConverter() : base(null, typeof(TDestinationResultType))
        {
        }

        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType);
        }

        public abstract TDestinationResultType? Convert(Enum sourceResultType);
    }
}
