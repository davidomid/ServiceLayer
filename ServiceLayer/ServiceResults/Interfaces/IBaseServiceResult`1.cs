using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IBaseServiceResult<out TResultType> where TResultType : Enum
    {
        TResultType ResultType { get; }

        IEnumerable<string> ErrorMessages { get; }

        bool IsSuccessful { get; }
    }
}
