using System.Net;
using ServiceLayer;
namespace ExampleServices
{
    public enum FileStorageResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        UnexpectedError,
        [ResultType(ResultType.Failure)]
        [ResultType(HttpStatusCode.BadRequest)]
        FilePathNotExists
    }
}
