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

        public Type SourceType { get; }
        public Type DestinationType { get; }

        public Enum Convert(Enum sourceResultType)
        {
            if (SourceType != null && sourceResultType.GetType() != SourceType)
            {
                throw new ArgumentException("The provided source result type does not match the source type of the converter.", nameof(sourceResultType));
            }

            if (SourceType == DestinationType)
            {
                return sourceResultType;
            }

            return null;
        }
    }
}
