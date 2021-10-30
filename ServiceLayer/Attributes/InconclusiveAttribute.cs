namespace ServiceLayer
{
    /// <summary>
    /// <para>This attribute maps the source enum value to the <see cref="ResultType.Inconclusive"/> result type.</para>
    /// <para>Use this attribute to mark enum values which should be considered inconclusive result types.</para>
    /// </summary>
    /// <remarks>By default, unless otherwise specified, ServiceLayer will consider an enum value to be an inconclusive result type.</remarks>
    /// <seealso cref="ResultTypeAttribute"/>
    public class InconclusiveAttribute : ResultTypeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InconclusiveAttribute"/> class
        /// </summary>
        public InconclusiveAttribute() : base(ServiceLayer.ResultType.Inconclusive)
        {
        }
    }
}
