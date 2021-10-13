using System;
namespace ServiceLayer
{
    /// <summary>
    /// <para>This attribute is used for annotating a source enum value and providing a destination value which it can be mapped to.</para>
    /// <para>This is used for converting between the source value and destination value, or from the destination value to the source value.</para>
    /// </summary>
    /// <seealso cref="Attribute"/>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class ResultTypeAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultTypeAttribute"/> class
        /// </summary>
        /// <param name="resultType">The destination value which the source enum value can be converted to.</param>
        public ResultTypeAttribute(object resultType)
        {
            ResultType = (Enum)resultType;
        }

        /// <summary>
        /// Gets the value of the result type
        /// </summary>
        public Enum ResultType { get; }

        /// <summary>
        /// <para>If set to true, a value of the given ResultType will be converted to the annotated enum value by default.</para>
        /// <para>This is useful when you have multiple values in the source enum annotated with the same destination value.</para>
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
