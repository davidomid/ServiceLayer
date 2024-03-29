using System;
using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer.UnitTests.Internal.ServiceLocator.Resolve
{
    [TestFixture(TypeArgs  = new[]{ typeof(IResultFactory), typeof(ResultFactory)})]
    [TestFixture(TypeArgs = new[] { typeof(IDataResultFactory), typeof(DataResultFactory) })]
    [TestFixture(TypeArgs = new[] { typeof(ISuccessResultFactory), typeof(SuccessResultFactory) })]
    [TestFixture(TypeArgs = new[] { typeof(IFailureResultFactory), typeof(FailureResultFactory) })]
    public class WhenGivenFactoryInterfaceType<TFactoryInterfaceType, TFactoryConcreteType> : UnitTestBase where TFactoryConcreteType : TFactoryInterfaceType where TFactoryInterfaceType : class
    {
        private object _factoryInstance;

        private readonly ServiceLayer.Internal.ServiceLocator _serviceLocator = (ServiceLayer.Internal.ServiceLocator)Activator.CreateInstance(typeof(ServiceLayer.Internal.ServiceLocator), true);

        protected override void Arrange()
        {
            
        }

        protected override void Act()
        {
            _factoryInstance = _serviceLocator.Resolve<TFactoryInterfaceType>();
        }

        [Test]
        public void Then_Returned_Factory_Should_Have_Expected_Type()
        {
            _factoryInstance.Should().BeOfType<TFactoryConcreteType>();
        }
    }
}

