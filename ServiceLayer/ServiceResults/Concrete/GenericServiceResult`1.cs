using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class GenericServiceResult<TResultType> : IGenericServiceResult<TResultType> where TResultType : Enum
    {
        protected GenericServiceResult(TResultType resultType, params string[] errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public TResultType ResultType { get; }

        public IEnumerable<string> ErrorMessages { get; }

        public bool IsSuccessful => this.ResultType.ToServiceResultType() == ServiceResultTypes.Success;
    }
}