using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Models.ServiceResult_2.Operators.Implicit
{
    public class From_SuccessResult : UnitTestBase
    {
        private readonly ServiceLayer.SuccessResult _successResult = new ServiceLayer.SuccessResult();

        private ServiceResult<TestCustomServiceResultTypes> _actualServiceResult;

        private ServiceResult<TestCustomServiceResultTypes> _expectedServiceResult;

        [Test]
        public void Should_Be_Expected_ServiceResult()
        {
            _actualServiceResult.Should().Be(_expectedServiceResult);
        }

        protected override void Arrange()
        {
            _expectedServiceResult = MockServiceResultFactory.Object.Create<TestCustomServiceResultTypes>(_successResult);
        }

        protected override void Act()
        {
            _actualServiceResult = _successResult;
        }
    }
}
