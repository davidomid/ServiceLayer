using ServiceLayer;

namespace Testing.Common.Domain.TestClasses
{
    public enum TestCustomResultTypes
    {
        TestValueWithNoAttribute,
        [Success]
        TestValueWithSuccessAttribute,
        [Failure]
        TestValueWithFailureAttribute
    }
}
