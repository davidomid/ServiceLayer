using System;

namespace ServiceLayer
{
    /// <summary>
    /// Inherit this abstract class to create your own result type converter which converts any source result type enum value to any destination result type enum.
    /// </summary>
    public abstract class AnyToAnyResultTypeConverter : ResultTypeConverter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyToAnyResultTypeConverter"/> class
        /// </summary>
        protected AnyToAnyResultTypeConverter() : base(null, null)
        {
        }
        
        internal override Enum PerformInternalConversion(Enum sourceResultType, Type destinationEnumType)
        {
            return this.Convert(sourceResultType, destinationEnumType);
        }

        /// <summary>
        /// <para>This needs to be implemented so that any source result type enum value can be converted to any destination result type enum.</para>
        /// </summary>
        /// <param name="sourceResultType">The source result type enum value.</param>
        /// <param name="destinationEnumType">The destination result type enum which the source result type value will be converted to.</param>
        /// <returns>
        ///     An <see cref="Enum"/> value with the same type as the given <paramref name="destinationEnumType"/>, after being converted from the given <paramref name="sourceResultType"/>.
        ///     <c>null</c> can be returned when no conversion to <paramref name="destinationEnumType"/> is possible.
        /// </returns>
        /// <remarks>
        ///     If no direct conversion from <paramref name="sourceResultType"/> to <paramref name="destinationEnumType"/> is possible, you can return <c>null</c>.
        ///     ServiceLayer will then automatically fall back to the next valid converter.
        ///     If you want to prevent ServiceLayer from falling back to the next converter, you can throw any <see cref="Exception"/>.
        /// </remarks>
        public abstract Enum Convert(Enum sourceResultType, Type destinationEnumType);
    }
}
