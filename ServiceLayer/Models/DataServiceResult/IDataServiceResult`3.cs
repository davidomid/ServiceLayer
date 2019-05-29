using System;

namespace ServiceLayer
{
    public interface IDataServiceResult<out TData, out TResultType, out TErrorType> : IDataServiceResult<TData, TResultType>, IServiceResult<TResultType, TErrorType> where TResultType : struct, Enum
    {
    }
}
