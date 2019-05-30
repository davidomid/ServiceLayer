using System;
namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType> : IConvertToResultType<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        protected ToResultTypeConverter()
        {
            SourceType = null;
            DestinationType = typeof(TDestinationResultType);
        }

        public Type DestinationType { get; }

        Enum IResultTypeConverter.Convert(Enum sourceResultType)
        {
            return Convert(sourceResultType);
        }

        public Type SourceType { get; }

        public TDestinationResultType Convert(Enum sourceResultType)
        {
            throw new NotImplementedException();
        }
    }
}
