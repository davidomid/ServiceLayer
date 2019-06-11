using FluentAssertions;
using NUnit.Framework;
using ServiceLayer.Internal.Factories;

namespace ServiceLayer.UnitTests.Internal.ServiceLocator.Resolve
{
    [TestFixture(TypeArgs  = new[]{ typeof(IServiceResultFactory), typeof(ServiceResultFactory)})]
    [TestFixture(TypeArgs = new[] { typeof(IDataServiceResultFactory), typeof(DataServiceResultFactory) })]
    [TestFixture(TypeArgs = new[] { typeof(ISuccessResultFactory), typeof(SuccessResultFactory) })]
    [TestFixture(TypeArgs = new[] { typeof(IFailureResultFactory), typeof(FailureResultFactory) })]
    public class WhenGivenFactoryInterfaceType<TFactoryInterfaceType, TFactoryConcreteType> : UnitTestBase where TFactoryConcreteType : TFactoryInterfaceType where TFactoryInterfaceType : class
    {
        private object _factoryInstance;

        private readonly ServiceLayer.Internal.ServiceLocator _serviceLocator = new ServiceLayer.Internal.ServiceLocator();

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

