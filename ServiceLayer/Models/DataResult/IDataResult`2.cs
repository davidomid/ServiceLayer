using System;

namespace ServiceLayer
{
    public interface IDataResult<out TData, out TResultType> : IDataResult<TData>, IResult<TResultType> where TResultType : struct, Enum
    {
    }
}
