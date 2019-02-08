using System;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType> : IServiceResult where TResultType : Enum
    {
        new TResultType ResultType { get; }
    }
}
