using ServiceLayer;
using ServiceLayer.Attributes;

namespace ExampleServices
{
    public enum FileStorageServiceResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        Failure,
        [ResultType(ServiceResultTypes.Failure)]
        FilePathNotExists

    }
}
