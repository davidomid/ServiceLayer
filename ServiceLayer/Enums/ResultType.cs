namespace ServiceLayer
{
    /// <summary>
    /// The default enum representing the status of a result returned from a service method.
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// Indicates that the result is neither a success or a failure. <b>This is the default value.</b>
        /// </summary>
        [DefaultResultType]
        Inconclusive = 0,
        /// <summary>
        /// Indicates that the result is a success.
        /// </summary>
        Success = 1,
        /// <summary>
        /// Indicates that the result is a failure.
        /// </summary>
        Failure = 2
    }
}