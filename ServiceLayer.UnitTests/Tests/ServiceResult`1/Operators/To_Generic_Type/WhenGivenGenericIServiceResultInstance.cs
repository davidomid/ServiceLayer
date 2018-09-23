using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Tests.Operators.To_Generic_Type
{
    public class WhenGivenGenericIServiceResultInstance : UnitTestBase
    {
        private const string TestData = "test data";
        private ServiceResult<string> _existingServiceResult;
        private string _newData;

        [Test]
        public void Should_Return_Value_Matching_ServiceResult_Data()
        {
            _newData.Should().Be(_existingServiceResult.Data);
        }

        protected override void Act()
        {
            _newData = _existingServiceResult;
        }

        protected override void Arrange()
        {
            _existingServiceResult = new OkResult<string>(TestData); 
        }
    }
}
