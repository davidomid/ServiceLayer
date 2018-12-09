using System;

namespace ServiceLayer
{
    public class CustomServiceResult<TResultType, TData> : CustomServiceResult<TResultType>, IServiceResult<TResultType, TData> where TResultType : Enum
    {
        public CustomServiceResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }

        public static implicit operator ServiceResult<TData>(CustomServiceResult<TResultType, TData> customServiceResult)
        {
            return new ServiceResult<TData>(customServiceResult.ResultType.ToServiceResultType(), customServiceResult.Data, customServiceResult.ErrorMessages);
        }
    }
}