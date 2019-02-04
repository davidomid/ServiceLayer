using ServiceLayer.Attributes;

namespace ExampleServices
{
    public enum FileStorageServiceResultTypes
    {
        [Success]
        Success,
        [Failure(IsDefault = true)]
        Failure,
        [Failure]
        FilePathNotExists
    }
}
