namespace ServiceLayer
{
    /// <summary>
    /// <para>This attribute maps the source enum value to the <see cref="ResultType.Success"/> result type.</para>
    /// <para>Use this attribute to mark enum values which should be considered successful result types.</para>
    /// </summary>
    /// <seealso cref="ResultTypeAttribute"/>
    public class SuccessAttribute : ResultTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessAttribute"/> class
        /// </summary>
        public SuccessAttribute() : base(ServiceLayer.ResultType.Success)
        {
        }
    }
}
