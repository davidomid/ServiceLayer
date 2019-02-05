using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class ServiceResult<TResultType> : IServiceResult<TResultType> where TResultType : Enum
    {
        public ServiceResult(TResultType resultType, params string[] errorMessages) : this(resultType, errorMessages.AsEnumerable())
        {
        }

        public ServiceResult(TResultType resultType, IEnumerable<string> errorMessages)
        {
            this.ResultType = resultType;
            this.ErrorMessages = errorMessages;
        }

        public TResultType ResultType { get; }
        public IEnumerable<string> ErrorMessages { get; }
        public bool IsSuccessful => this.ResultType.ToServiceResultType() == ServiceResultTypes.Success;

        ServiceResultTypes IServiceResult.ResultType => ResultType.ToServiceResultType();
    }
}