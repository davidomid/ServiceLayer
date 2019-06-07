using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class OneToOneResultTypeConverter<TDestinationResultType, TSourceResultType> : ResultTypeConverter, IOneToOneResultTypeConverter<TDestinationResultType, TSourceResultType> where TDestinationResultType : struct, Enum where TSourceResultType : struct, Enum
    {
        protected OneToOneResultTypeConverter() : base(typeof(TSourceResultType), typeof(TDestinationResultType))
        {
        }

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert((TSourceResultType) sourceResultType);
        }

        public abstract TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
