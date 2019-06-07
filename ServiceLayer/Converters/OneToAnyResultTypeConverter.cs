﻿using System;
using System.Reflection;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer.Converters
{
    public abstract class OneToAnyResultTypeConverter<TSourceResultType> : ResultTypeConverter, IFromResultTypeConverter<TSourceResultType> where TSourceResultType : Enum
    {
        protected OneToAnyResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }

        public abstract TDestinationResultType? Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;

        internal override Enum Convert(Enum sourceResultType, Type destinationEnumType)
        {
            var genericConvertMethod = GetType()
                .GetTypeInfo()
                .GetDeclaredMethod(nameof(Convert))
                .MakeGenericMethod(destinationEnumType);

            try
            {
                object result = genericConvertMethod.Invoke(this, new object[] {sourceResultType});
                Enum destinationResultType = (Enum) System.Convert.ChangeType(result, destinationEnumType);
                return destinationResultType;
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }
    }
}
