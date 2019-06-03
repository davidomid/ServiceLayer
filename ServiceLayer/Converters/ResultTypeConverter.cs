using System;
using System.Reflection;

namespace ServiceLayer.Converters
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
            var convertWithValidationMethod = typeof(ResultTypeConverter)
                .GetTypeInfo()
                .GetDeclaredMethod(nameof(ConvertWithValidation))
                .MakeGenericMethod(destinationEnumType);
            object result = convertWithValidationMethod.Invoke(this, new object[] { sourceResultType });
            Enum destinationResultType = (Enum)System.Convert.ChangeType(result, destinationEnumType);
            return destinationResultType;
        }

        internal TDestinationResultType ConvertWithValidation<TDestinationResultType>(Enum sourceResultType) where TDestinationResultType : Enum
        {
            if (SourceType != null && sourceResultType.GetType() != SourceType)
            {
                throw new ArgumentException("The provided source result type does not match the source type of the converter.", nameof(sourceResultType));
            }

            if (DestinationType != null && typeof(TDestinationResultType) != DestinationType)
            {
                throw new ArgumentException("The provided destination result type does not match the destination type of the converter.", nameof(sourceResultType));
            }

            if (sourceResultType.GetType() == DestinationType)
            {
                return (TDestinationResultType)sourceResultType;
            }

            try
            {
                return (TDestinationResultType) Convert(sourceResultType, typeof(TDestinationResultType));
            }
            catch (Exception ex)
            {
                throw new InvalidCastException(
                    $"Could not convert enum value of type {sourceResultType.GetType()} to a value of type {typeof(TDestinationResultType)}",
                    ex);
            }
        }

        Type IResultTypeConverter.SourceType => SourceType;

        Type IResultTypeConverter.DestinationType => DestinationType;
    }
}
