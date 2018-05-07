using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IServiceResult
    {
        ServiceResultTypes ResultType { get; }
        IEnumerable<string> ErrorMessages { get; }
    }
}