using ServiceLayer;

namespace Testing.Common.Domain.TestClasses
{
    public enum TestCustomServiceResultTypes
    {
        TestValueWithNoAttribute,
        [Success]
        TestValueWithSuccessAttribute,
        [Failure]
        TestValueWithFailureAttribute
    }
}
