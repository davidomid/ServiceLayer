using System;

namespace ServiceLayer
{
    public interface IDataServiceResult<out TData, out TResultType> : IServiceResult<TResultType> where TResultType : Enum
    {
        TData Data { get; }
    }
}
