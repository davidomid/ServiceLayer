﻿using ServiceLayer.Internal;

namespace ServiceLayer
{
    public class FailureResult<TErrorType> : FailureResult
    {
        public FailureResult(TErrorType errorDetails) : base(errorDetails)
        {
            ErrorDetails = errorDetails;
        }

        public new TErrorType ErrorDetails { get; }

        public static implicit operator FailureResult<TErrorType>(TErrorType errorDetails)
        {
            return Engine.FailureResultFactory.Create(errorDetails);
        }
    }
}
