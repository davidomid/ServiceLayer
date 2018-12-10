using System;

namespace ServiceLayer
{
    public interface IGenericServiceResult<out TResultType, out TData> : IGenericServiceResult<TResultType> where TResultType : Enum
    {
         TData Data { get; }
    }
}
