using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TData> : IServiceResult
    {
        TData Data { get; }
    }
}
