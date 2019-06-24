using ServiceLayer;

namespace Testing.Common.Domain.TestClasses
{
    public enum TestCustomResultType
    {
        TestValueWithNoAttribute,
        [Success]
        TestValueWithSuccessAttribute,
        [Failure]
        TestValueWithFailureAttribute
    }
}
