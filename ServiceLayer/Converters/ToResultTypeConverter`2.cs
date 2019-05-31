using System;
namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType, TSourceResultType> : ResultTypeConverter, IToResultTypeConverter<TDestinationResultType, TSourceResultType> where TDestinationResultType : struct, Enum where TSourceResultType : struct, Enum
    {
        protected ToResultTypeConverter() : base(typeof(TSourceResultType), typeof(TDestinationResultType))
        {
        }

        Enum IResultTypeConverter.Convert(Enum sourceResultType)
        {
            return base.Convert(sourceResultType) ?? Convert(sourceResultType);
        }

        public abstract TDestinationResultType Convert(TSourceResultType sourceResultType); 
    }
}
