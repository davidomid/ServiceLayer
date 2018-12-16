using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain;

namespace ServiceLayer.UnitTests.Models.SuccessResult.Constructor
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private ServiceLayer.SuccessResult _successResult;

        [Test]
        public void Should_Have_Success_ServiceResultType()
        {
            _successResult.ResultType.Should().Be(ServiceResultTypes.Success);
        }

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
           _successResult = new ServiceLayer.SuccessResult();
        }
    }
}
