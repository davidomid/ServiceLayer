using System;
namespace ServiceLayer.Converters
{
    public abstract class ToResultTypeConverter<TDestinationResultType, TSourceResultType> : IConvertToResultType<TDestinationResultType, TSourceResultType> where TDestinationResultType : struct, Enum where TSourceResultType : struct, Enum
    {
        protected ToResultTypeConverter()
        {
            SourceType = typeof(TSourceResultType);
            DestinationType = typeof(TDestinationResultType);
        }

        public Type DestinationType { get; }

        Enum IResultTypeConverter.Convert(Enum sourceResultType)
        {
            if (sourceResultType.GetType() == SourceType)
            {
                return Convert((TSourceResultType)sourceResultType);
            }

            return null;
        }

        public Type SourceType { get; }

        public TDestinationResultType Convert(TSourceResultType sourceResultType)
        {
            throw new NotImplementedException();
        }

    }
}
