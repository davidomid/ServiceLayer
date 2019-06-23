using System;

namespace ServiceLayer
{
    public interface IResult<out TResultType> : IResult where TResultType : struct, Enum
    {
        new TResultType ResultType { get; }
    }
}
