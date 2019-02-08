using System;

namespace ServiceLayer
{
    public interface IDataServiceResult<out TData, out TResultType> : IDataServiceResult<TData>, IServiceResult<TResultType> where TResultType : Enum
    {
    }
}
