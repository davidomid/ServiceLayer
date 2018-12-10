using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class ServiceResult<TResultType> : IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, params string[] errorMessages) 
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public TResultType ResultType { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public bool IsSuccessful => this.ResultType.ToServiceResultType() == ServiceResultTypes.Success;
    }
}