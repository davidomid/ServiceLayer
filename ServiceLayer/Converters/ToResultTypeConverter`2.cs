using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType, TSourceResultType> : ResultTypeConverter, IToResultTypeConverter<TDestinationResultType, TSourceResultType> where TDestinationResultType : struct, Enum where TSourceResultType : struct, Enum
    {
        protected ToResultTypeConverter() : base(typeof(TSourceResultType), typeof(TDestinationResultType))
        {
        }

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert((TSourceResultType) sourceResultType);
        }

        public abstract TDestinationResultType Convert(TSourceResultType sourceResultType);
    }
}
