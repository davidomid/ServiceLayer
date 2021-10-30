using System;
using ServiceLayer.Internal.Converters;

namespace ServiceLayer
{
    /// <summary>
    /// Inherit this abstract class to create your own result type converter which converts any source result type enum value to a given <typeparamref name="TDestinationResultType"/> enum.
    /// </summary>
    /// <typeparam name="TDestinationResultType">The destination result type enum which any given source result types will be converted to.</typeparam>
    public abstract class AnyToOneResultTypeConverter<TDestinationResultType> : ResultTypeConverter, IAnyToOneResultTypeConverter<TDestinationResultType> where TDestinationResultType : struct, Enum
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyToOneResultTypeConverter{TDestinationResultType}"/> class
        /// </summary>
        protected AnyToOneResultTypeConverter() : base(null, typeof(TDestinationResultType))
        {
        }

        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType);
        }
        
        /// <summary>
        /// <para>This needs to be implemented so that any source result type enum value can be converted to the given <typeparamref name="TDestinationResultType"/> destination result type enum.</para>
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
        public abstract TDestinationResultType? Convert(Enum sourceResultType);
    }
}
