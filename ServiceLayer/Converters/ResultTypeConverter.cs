using System;

namespace ServiceLayer.Converters
{
    public abstract class ResultTypeConverter : IResultTypeConverter
    {
        protected ResultTypeConverter(Type sourceType, Type destinationType)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        private Type SourceType { get; }
        private Type DestinationType { get; }

        public TDestinationResultType? Convert<TDestinationResultType>(Enum sourceResultType) where TDestinationResultType : struct, Enum
        {
            if (SourceType != null && sourceResultType.GetType() != SourceType)
            {
                throw new ArgumentException("The provided source result type does not match the source type of the converter.", nameof(sourceResultType));
            }

            if (SourceType == DestinationType || typeof(TDestinationResultType) == sourceResultType.GetType())
            {
                return (TDestinationResultType)sourceResultType;
            }

            return null;
        }

        Type IResultTypeConverter.SourceType => SourceType;

        Type IResultTypeConverter.DestinationType => DestinationType;
    }
}
