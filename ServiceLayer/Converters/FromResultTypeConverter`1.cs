using System;
using System.Reflection;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class FromResultTypeConverter<TSourceResultType> : ResultTypeConverter, IFromResultTypeConverter<TSourceResultType> where TSourceResultType : Enum
    {
        protected FromResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }

        public abstract TDestinationResultType Convert<TDestinationResultType>(TSourceResultType sourceResultType)
            where TDestinationResultType : Enum;

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            var genericConvertMethod = GetType()
                .GetTypeInfo()
                .GetDeclaredMethod(nameof(Convert))
                .MakeGenericMethod(destinationEnumType);

            object result = genericConvertMethod.Invoke(this, new object[] { sourceResultType });
            Enum destinationResultType = (Enum)System.Convert.ChangeType(result, destinationEnumType);
            return destinationResultType;
        }
    }
}
