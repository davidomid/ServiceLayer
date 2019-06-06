using ServiceLayer.Attributes;

namespace ServiceLayer
{
    public enum ServiceResultTypes
    {
        Success,
        [DefaultResultType]
        Failure
    }
}