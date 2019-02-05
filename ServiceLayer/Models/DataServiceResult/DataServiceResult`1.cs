using System.Collections.Generic;

namespace ServiceLayer
{
    public class DataServiceResult<TData> : DataServiceResult<TData, ServiceResultTypes>
    {
        public DataServiceResult(TData data, ServiceResultTypes resultType, params string[] errorMessages) : base(data, resultType, errorMessages)
        {
        }

        public DataServiceResult(TData data, ServiceResultTypes resultType, IEnumerable<string> errorMessages) : base(data, resultType, errorMessages)
        {
        }

        public static implicit operator DataServiceResult<TData>(TData data)
        {
            return new SuccessResult<TData>(data);
        }

        public static implicit operator DataServiceResult<TData>(FailureResult failureResult)
        {
            return new DataServiceResult<TData>(default, ServiceResultTypes.Failure, failureResult.ErrorMessages);
        }

        public static implicit operator DataServiceResult<TData>(ServiceResultTypes resultType)
        {
            return new DataServiceResult<TData>(default, resultType);
        }
    }
}