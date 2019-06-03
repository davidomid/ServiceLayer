using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class FromResultTypeConverter<TSourceResultType> : ResultTypeConverter, IFromResultTypeConverter<TSourceResultType> where TSourceResultType : struct, Enum
    {
        protected FromResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }

        TDestinationResultType? IResultTypeConverter.Convert<TDestinationResultType>(Enum sourceResultType)
        {
            return base.Convert<TDestinationResultType>(sourceResultType) ?? Convert<TDestinationResultType>((TSourceResultType)sourceResultType);
        }

        public new abstract TDestinationResultType? Convert<TDestinationResultType>(Enum sourceResultType)
            where TDestinationResultType : struct, Enum;
    }
}
