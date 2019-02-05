using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IServiceResult<out TResultType> : IServiceResult where TResultType : Enum
    {
        new TResultType ResultType { get; }

        IEnumerable<string> ErrorMessages { get; }

        bool IsSuccessful { get; }
    }
}
