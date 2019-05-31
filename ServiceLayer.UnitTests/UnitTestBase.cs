using Moq;
using NUnit.Framework;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;
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
        internal static readonly Mock<IResultTypeConversionService> MockResultTypeConversionService = new Mock<IResultTypeConversionService>();

        static UnitTestBase()
        {
            Mock<IServiceLocator> mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(MockResultTypeConversionService.Object);
            mockServiceLocator.Setup(l => l.Resolve<IServiceResultFactory>()).Returns(MockServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IDataServiceResultFactory>()).Returns(MockDataServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<ISuccessResultFactory>()).Returns(MockSuccessResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IFailureResultFactory>()).Returns(MockFailureResultFactory.Object);
            ServiceLocator.Instance = mockServiceLocator.Object;

            SetupMockResultTypeConversionService();
            SetupMockServiceResultFactory();
            SetupMockDataServiceResultFactory();
            SetupMockSuccessResultFactory();
            SetupMockFailureResultFactory();

        }

        private static void SetupMockResultTypeConversionService()
        {
            MockResultTypeConversionService.Setup(s => s.Convert<ServiceResultTypes>(ServiceResultTypes.Success))
                .Returns(ServiceResultTypes.Success);
            MockResultTypeConversionService.Setup(s => s.Convert<ServiceResultTypes>(ServiceResultTypes.Failure))
                .Returns(ServiceResultTypes.Failure);
        }

        private static void SetupMockSuccessResultFactory()
        {
            MockSuccessResultFactory.Setup(f => f.Create())
                .Returns(new SuccessResult());
            MockSuccessResultFactory.Setup(f => f.Create(It.IsAny<TestData>()))
                .Returns(new SuccessResult<TestData>(default)); 
        }

        private static void SetupMockFailureResultFactory()
        {
            MockFailureResultFactory.Setup(f => f.Create()).Returns(new FailureResult());
            MockFailureResultFactory.Setup(f => f.Create(It.IsAny<object[]>()))
                .Returns(new FailureResult<object[]>(new object[] { default, default, default}));
            MockFailureResultFactory.Setup(f => f.Create(It.IsAny<TestErrorType>()))
                .Returns(new FailureResult<TestErrorType>(default));
        }

        private static void SetupMockServiceResultFactory()
        {
            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ServiceResultTypes>()))
                .Returns(new ServiceResult(default));
            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new ServiceResult<ServiceResultTypes, string[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes>(default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, object[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new ServiceResult<ServiceResultTypes, object[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<TestErrorType>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<SuccessResult>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes, string[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes>(It.IsAny<SuccessResult>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes>(TestCustomServiceResultTypes.TestValueWithSuccessAttribute));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes>(It.IsAny<FailureResult>()))
                .Returns(new ServiceResult<TestCustomServiceResultTypes>(TestCustomServiceResultTypes.TestValueWithNoAttribute));
        }

        private static void SetupMockDataServiceResultFactory()
        {
            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<ServiceResultTypes>()))
                .Returns(new DataServiceResult<TestData>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<FailureResult>()))
                .Returns(new DataServiceResult<TestData>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<TestData>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<FailureResult>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestData>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>()))
                .Returns(new DataServiceResult<TestData>(default, default)); 

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<TestErrorType>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, object[]>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, string[]>(default, default, default));

        }
    }
}
