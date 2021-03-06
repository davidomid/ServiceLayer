﻿using System;
using System.Reflection;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    public abstract class OneToAnyResultTypeConverter<TSourceResultType> : ResultTypeConverter, IOneToAnyResultTypeConverter<TSourceResultType> where TSourceResultType : Enum
    {
        protected OneToAnyResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }

        public abstract TDestinationResultType? Convert<TDestinationResultType>(TSourceResultType sourceResultType) where TDestinationResultType : struct, Enum;

        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            var genericConvertMethod = GetType()
                .GetTypeInfo()
                .GetDeclaredMethod(nameof(PerformInternalConversion))
                .MakeGenericMethod(destinationEnumType);

            try
            {
                object result = genericConvertMethod.Invoke(this, new object[] {sourceResultType});
                Enum destinationResultType = (Enum) System.Convert.ChangeType(result, destinationEnumType);
                return destinationResultType;
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException != null)
                {
                    throw tie.InnerException;
                }
            }

            return null;
        }
    }
}
