using System;
namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : ServiceResult<TResultType>, IDataServiceResult<TData, TResultType> where TResultType : Enum
    {
        public DataServiceResult(TResultType resultType, TData data, params string[] errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }

        public TData Data { get; }
    }
}