using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType, out TErrorType> : IServiceResult<TResultType> where TResultType : Enum
    {
        new TErrorType ErrorDetails { get; }
    }
}
