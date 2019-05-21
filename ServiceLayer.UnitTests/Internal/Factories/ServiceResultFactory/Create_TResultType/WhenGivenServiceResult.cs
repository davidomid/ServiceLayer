﻿using System;
using System.Runtime.InteropServices;
using FluentAssertions;
using NUnit.Framework;
using Testing.Common.Domain.TestClasses;

namespace ServiceLayer.UnitTests.Internal.Factories.ServiceResultFactory.Create_TResultType
{
    [TestFixtureSource(nameof(ResultTypes))]
    public class WhenGivenServiceResult : UnitTestBase
    {
        private readonly ServiceLayer.Internal.Factories.ServiceResultFactory _serviceResultFactory =
            new ServiceLayer.Internal.Factories.ServiceResultFactory();

        private ServiceResult<TestCustomServiceResultTypes> _serviceResult;

        private ServiceResult _fromServiceResult;

        private readonly ServiceResultTypes _resultType;

        private object[] _errorDetails; 

        private static readonly ServiceResultTypes[] ResultTypes = (ServiceResultTypes[])Enum.GetValues(typeof(ServiceResultTypes));

        public WhenGivenServiceResult(ServiceResultTypes resultType)
        {
            _resultType = resultType;
        }

        protected override void Arrange()
        {
            _errorDetails = new[] {"test 123", 123, new object()};
            _fromServiceResult = new ServiceResult(_resultType, _errorDetails);
        }

        protected override void Act()
        {
            _serviceResult = _serviceResultFactory.Create<TestCustomServiceResultTypes>(_fromServiceResult); 
        }

        [Test]
        public void Should_Not_Return_Null()
        {
            _serviceResult.Should().NotBeNull();
        }

        [Test]
        public void Should_Return_Result_With_Given_ErrorDetails()
        {
            _serviceResult.ErrorDetails.Should().Be(_errorDetails); 
        }

        [Test]
        public void Should_Return_Result_With_Expected_ResultType()
        {
            _serviceResult.ResultType.Should().Be(_resultType.ToResultType<TestCustomServiceResultTypes>());
        }
    }
}