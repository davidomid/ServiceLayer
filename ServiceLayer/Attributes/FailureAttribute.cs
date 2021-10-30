namespace ServiceLayer
{
    /// <summary>
    /// <para>This attribute maps the source enum value to the <see cref="ResultType.Failure"/> result type.</para>
    /// <para>Use this attribute to mark enum values which should be considered failure result types.</para>
    /// </summary>
    /// <seealso cref="ResultTypeAttribute"/>
    public class FailureAttribute : ResultTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FailureAttribute"/> class
        /// </summary>
        public FailureAttribute() : base(ServiceLayer.ResultType.Failure)
        {
        }
    }
}
