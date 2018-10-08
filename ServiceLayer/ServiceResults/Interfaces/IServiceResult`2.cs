using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TData, out TResultType> : IServiceResult<TData> where TResultType : Enum
    {
        new TResultType ResultType { get; }
    }
}
