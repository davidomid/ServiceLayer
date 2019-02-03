using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class DataServiceResult<TData> : DataServiceResult<TData, ServiceResultTypes>, IDataServiceResult<TData>
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
            return new DataServiceResult<TData>(default(TData), ServiceResultTypes.Failure, failureResult.ErrorMessages);
        }
    }
}