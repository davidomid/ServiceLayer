using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    public abstract class OneToOneResultTypeConverter<TSourceResultType, TDestinationResultType> : ResultTypeConverter, IOneToOneResultTypeConverter<TSourceResultType, TDestinationResultType> where TDestinationResultType : struct, Enum where TSourceResultType : struct, Enum
    {
        protected OneToOneResultTypeConverter() : base(typeof(TSourceResultType), typeof(TDestinationResultType))
        {
        }

        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert((TSourceResultType) sourceResultType);
        }

        public abstract TDestinationResultType? Convert(TSourceResultType sourceResultType);
    }
}
