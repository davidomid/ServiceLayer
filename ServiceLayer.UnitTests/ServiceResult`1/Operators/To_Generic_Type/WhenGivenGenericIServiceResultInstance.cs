using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Operators.To_Generic_Type
{
    public class WhenGivenGenericIServiceResultInstance : NUnitTestBase
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
