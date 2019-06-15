using System.Net;
using ServiceLayer;
namespace ExampleServices
{
    public enum FileStorageServiceResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        Failure,
        [ResultType(ServiceResultTypes.Failure)]
        [ResultType(HttpStatusCode.BadRequest)]
        FilePathNotExists
    }
}
