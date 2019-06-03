using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType> : ResultTypeConverter, IToResultTypeConverter<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        protected ToResultTypeConverter() : base(null, typeof(TDestinationResultType))
        {
        }

        Enum IResultTypeConverter.Convert(Enum sourceResultType)
        {
            return base.Convert(sourceResultType) ?? Convert(sourceResultType);
        }

        public new abstract TDestinationResultType Convert(Enum sourceResultType);
    }
}
