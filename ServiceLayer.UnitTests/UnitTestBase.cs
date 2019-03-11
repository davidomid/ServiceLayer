using Moq;
using NUnit.Framework;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using Testing.Common.Domain.TestClasses;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests
{
    [Parallelizable(ParallelScope.None)]
    public abstract class UnitTestBase : NUnitTestBase
    {
        internal static readonly Mock<IServiceResultFactory> MockServiceResultFactory = new Mock<IServiceResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IDataServiceResultFactory> MockDataServiceResultFactory = new Mock<IDataServiceResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<ISuccessResultFactory> MockSuccessResultFactory = new Mock<ISuccessResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IFailureResultFactory> MockFailureResultFactory = new Mock<IFailureResultFactory>(MockBehavior.Strict);

        static UnitTestBase()
        {
            Mock<IServiceLocator> mockServiceLocator = new Mock<IServiceLocator>(MockBehavior.Strict);

            SetupMockDataServiceResultFactory();
            mockServiceLocator.Setup(l => l.Resolve<IServiceResultFactory>()).Returns(MockServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IDataServiceResultFactory>()).Returns(MockDataServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<ISuccessResultFactory>()).Returns(MockSuccessResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IFailureResultFactory>()).Returns(MockFailureResultFactory.Object);
            ServiceLocator.Instance = mockServiceLocator.Object;
        }

        static void SetupMockDataServiceResultFactory()
        {
            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), default))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));
        }
    }
}
