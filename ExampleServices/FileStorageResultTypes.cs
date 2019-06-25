using System.Net;
using ServiceLayer;
namespace ExampleServices
{
    public enum FileStorageResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        Failure,
        [ResultType(ResultType.Failure)]
        [ResultType(HttpStatusCode.BadRequest)]
        FilePathNotExists
    }
}
