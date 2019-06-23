using System;

namespace ServiceLayer
{
    public interface IDataResult<out TData, out TResultType, out TErrorType> : IDataResult<TData, TResultType>, IResult<TResultType, TErrorType> where TResultType : struct, Enum
    {
    }
}
