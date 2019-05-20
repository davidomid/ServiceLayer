using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace ServiceLayer.UnitTests.Internal.Factories.SuccessResultFactory.Create
{
    public class WhenGivenNoArguments : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.SuccessResultFactory _successResultFactory =
            new ServiceLayer.Internal.Factories.SuccessResultFactory();

        private SuccessResult _successResult;

        protected override void Arrange()
        {
        }

        protected override void Act()
        {
            _successResult = _successResultFactory.Create(); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _successResult.Should().NotBeNull();
        }
    }
}
