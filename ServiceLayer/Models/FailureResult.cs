﻿namespace ServiceLayer
{
    public class FailureResult : ServiceResult
    {
        public FailureResult() : this(null)
        {
        }

        public FailureResult(params object[] errorDetails) : base(ServiceResultTypes.Failure, errorDetails)
        {
        }
    }
}
