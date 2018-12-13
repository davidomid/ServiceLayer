using ServiceLayer.Attributes;

namespace Testing.Common.Domain.TestData
{
    public enum TestCustomServiceResultTypes
    {
        TestValueWithNoAttribute,
        [Success]
        TestValueWithSuccessAttribute
    }
}
