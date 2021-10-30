using System;
using System.Reflection;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    /// <summary>
    /// Inherit this abstract class to create your own result type converter which converts between a specific <typeparamref name="TSourceResultType"/> source type and any destination type.
    /// </summary>
    /// <typeparam name="TSourceResultType">The source result type enum which any given destination result types will be converted from.</typeparam>
    public abstract class OneToAnyResultTypeConverter<TSourceResultType> : ResultTypeConverter, IOneToAnyResultTypeConverter<TSourceResultType> where TSourceResultType : Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneToAnyResultTypeConverter{TSourceResultType}"/> class
        /// </summary>
        protected OneToAnyResultTypeConverter() : base(typeof(TSourceResultType), null)
        {
        }
        
        /// <summary>
        /// <para>This needs to be implemented so that the given <typeparamref name="TSourceResultType"/> source result type enum value can be converted to a given <typeparamref name="TDestinationResultType"/> destination result type enum.</para>
        /// </summary>
        /// <typeparam name="TDestinationResultType">The destination result type enum which the given <paramref name="sourceResultType"/> will be converted to.</typeparam>
        /// <param name="sourceResultType">The source result type enum value.</param>
        /// <returns>
        ///     A resulting <typeparamref name="TDestinationResultType"/> value after converting from the given <paramref name="sourceResultType"/>.
        ///     <c>null</c> can be returned when no conversion to <typeparamref name="TDestinationResultType"/> is possible.
        /// </returns>
        /// <remarks>
        ///     If no direct conversion from <paramref name="sourceResultType"/> to <typeparamref name="TDestinationResultType"/> is possible, you can return <c>null</c>.
        ///     ServiceLayer will then automatically fall back to the next valid converter.
        ///     If you want to prevent ServiceLayer from falling back to the next converter, you can throw any <see cref="Exception"/>.
        /// </remarks>
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
