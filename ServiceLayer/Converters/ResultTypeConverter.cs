using System;

namespace ServiceLayer
{
    public abstract class ResultTypeConverter : IResultTypeConverter
    {
        protected ResultTypeConverter(Type sourceType, Type destinationType)
        {
            SourceType = sourceType;
            DestinationType = destinationType;
        }

        internal Type SourceType { get; }
        internal Type DestinationType { get; }

        internal abstract Enum Convert(Enum sourceResultType, Type destinationEnumType);

        Enum IResultTypeConverter.Convert(Enum sourceResultType, Type destinationEnumType)
        {
            return ConvertWithValidation(sourceResultType, destinationEnumType);
        }

        internal Enum ConvertWithValidation(Enum sourceResultType, Type destinationEnumType) 
        {
            if (SourceType != null && sourceResultType.GetType() != SourceType)
            {
                throw new ArgumentException("The provided source result type does not match the source type of the converter.", nameof(sourceResultType));
            }

            if (DestinationType != null && destinationEnumType != DestinationType)
            {
                throw new ArgumentException("The provided destination result type does not match the destination type of the converter.", nameof(sourceResultType));
            }

            if (sourceResultType.GetType() == destinationEnumType)
            {
                return sourceResultType;
            }

            try
            {
                return Convert(sourceResultType, destinationEnumType);
            }
            catch (Exception ex)
            {
                throw new InvalidCastException(
                    $"Could not convert enum value of type {sourceResultType.GetType()} to a value of type {destinationEnumType}",
                    ex);
            }
        }
    }
}
