using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IServiceResult
    {
        IEnumerable<string> ErrorMessages { get; }

        ServiceResultTypes ResultType { get; }
    }
}
