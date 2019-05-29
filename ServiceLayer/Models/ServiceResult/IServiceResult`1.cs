using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType> : IServiceResult where TResultType : struct, Enum
    {
        new TResultType ResultType { get; }
    }
}
