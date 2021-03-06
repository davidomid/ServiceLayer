﻿using System;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ResultFactory.Create_TResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ResultFactory _resultFactory =
            new ServiceLayer.Internal.Factories.ResultFactory();

        private Result<TestCustomResultType> _result;

        private Result _fromResult;

        private readonly ResultType _resultType;

        private readonly TestCustomResultType _expectedCustomResultType = (TestCustomResultType) 1000;

        private static readonly ResultType[] ResultTypes = (ResultType[])Enum.GetValues(typeof(ResultType));

        public WhenGivenResult(ResultType resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<TestCustomResultType>(_resultType))
                .Returns(_expectedCustomResultType);
            _fromResult = new Result(_resultType);
        }

        protected override void Act()
        {
            _result = _resultFactory.Create<TestCustomResultType>(_fromResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _result.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _result.ResultType.Should().Be(_expectedCustomResultType);
        }
    }
}
