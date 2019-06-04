using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType> : ResultTypeConverter, IToResultTypeConverter<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        protected ToResultTypeConverter() : base(null, typeof(TDestinationResultType))
        {
        }

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType);
        }

        public abstract TDestinationResultType Convert(Enum sourceResultType);
    }
}
