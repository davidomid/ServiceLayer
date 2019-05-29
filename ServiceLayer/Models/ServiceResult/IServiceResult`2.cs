using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType, out TErrorType> : IServiceResult<TResultType> where TResultType : struct, Enum
    {
        new TErrorType ErrorDetails { get; }
    }
}
