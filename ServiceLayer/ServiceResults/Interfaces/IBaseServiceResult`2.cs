using System;

namespace ServiceLayer
{
    public interface IBaseServiceResult<out TResultType, out TData> : IBaseServiceResult<TResultType> where TResultType : Enum
    {
         TData Data { get; }
    }
}
