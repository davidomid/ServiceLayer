using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer
{
    public class DataServiceResult<TData, TResultType> : ServiceResult<TResultType>, IDataServiceResult<TData, TResultType> where TResultType : Enum
    {
        public DataServiceResult(TData data, TResultType resultType, params string[] errorMessages) : this(data, resultType, errorMessages.AsEnumerable())
        {
        }

        public DataServiceResult(TData data, TResultType resultType, IEnumerable<string> errorMessages) : base(resultType, errorMessages)
        {
            this.Data = data;
        }


        public TData Data { get; }
    }
}