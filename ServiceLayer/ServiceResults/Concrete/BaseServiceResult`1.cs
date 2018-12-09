using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public abstract class BaseServiceResult<TResultType> : IBaseServiceResult<TResultType> where TResultType : Enum
    {
        protected BaseServiceResult(TResultType resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public TResultType ResultType { get; }

        public IEnumerable<string> ErrorMessages { get; }

        public bool IsSuccessful => this.ResultType.ToServiceResultType() == ServiceResultTypes.Success;
    }
}