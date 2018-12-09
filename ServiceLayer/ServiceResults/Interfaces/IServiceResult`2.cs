using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType, out TData> : IServiceResult<TResultType> where TResultType : Enum
    {
        TData Data { get; }
    }
}
