using System;
namespace ServiceLayer.Converters
{
    public abstract class FromResultTypeConverter<TSourceResultType> : IConvertFromResultType<TSourceResultType> where TSourceResultType : struct, Enum
    {
        protected FromResultTypeConverter()
        {
            DestinationType = null;
            SourceType = typeof(TSourceResultType);
        }

        public Type DestinationType { get; }

        public Enum Convert(Enum sourceResultType)
        {
            throw new NotImplementedException();
        }

        public Type SourceType { get; }

        public TDestinationResultType Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum
        {
            return (TDestinationResultType)this.Convert(sourceResultType);
        }

    }
}
