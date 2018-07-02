using ServiceLayer.Enums;
using System.Collections.Generic;

namespace ServiceLayer.Results
{
    public interface IServiceResult
    {
        ServiceResultTypes ResultType { get; }
        IEnumerable<string> ErrorMessages { get; }
    }
}