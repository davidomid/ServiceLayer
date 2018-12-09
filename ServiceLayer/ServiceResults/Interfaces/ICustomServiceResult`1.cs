using System;

namespace ServiceLayer
{
    public interface ICustomServiceResult<out TResultType> : IServiceResult<TResultType> where TResultType : Enum
    {
        new TResultType ResultType { get; }
    }
}
