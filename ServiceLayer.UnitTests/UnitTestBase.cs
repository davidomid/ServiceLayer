using Moq;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;
using Testing.Common.Domain.TestClasses;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests
{
    public abstract class UnitTestBase : ScenarioUnitTestBase
    {
        internal static readonly Mock<IServiceResultFactory> MockServiceResultFactory = new Mock<IServiceResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IDataServiceResultFactory> MockDataServiceResultFactory = new Mock<IDataServiceResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<ISuccessResultFactory> MockSuccessResultFactory = new Mock<ISuccessResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IFailureResultFactory> MockFailureResultFactory = new Mock<IFailureResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IResultTypeConversionService> MockResultTypeConversionService = new Mock<IResultTypeConversionService>(MockBehavior.Strict);

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
            MockResultTypeConversionService.Setup(s => s.Convert<ResultTypes>(ResultTypes.Success))
                .Returns(ResultTypes.Success);
            MockResultTypeConversionService.Setup(s => s.Convert<ResultTypes>(ResultTypes.Failure))
                .Returns(ResultTypes.Failure);
            MockResultTypeConversionService.Setup(s => s.Convert<ResultTypes>(ResultTypes.Inconclusive))
                .Returns(ResultTypes.Inconclusive);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultTypes>(TestCustomServiceResultTypes.TestValueWithNoAttribute))
                .Returns(ResultTypes.Failure);
            MockResultTypeConversionService.Setup(s =>
                s.Convert<ResultTypes>(TestCustomServiceResultTypes.TestValueWithSuccessAttribute))
                .Returns(ResultTypes.Success);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultTypes>(TestCustomServiceResultTypes.TestValueWithFailureAttribute))
                .Returns(ResultTypes.Failure);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultTypes>((TestCustomServiceResultTypes) 1000))
                .Returns(ResultTypes.Failure);
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
                .Setup(f => f.Create(It.IsAny<ResultTypes>()))
                .Returns(new Result(default));
            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ResultTypes>(), It.IsAny<string[]>()))
                .Returns(new Result<ResultTypes, string[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new Result<TestCustomServiceResultTypes>(default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new Result<TestCustomServiceResultTypes, object[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ResultTypes>(), It.IsAny<object[]>()))
                .Returns(new Result<ResultTypes, object[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<TestErrorType>()))
                .Returns(new Result<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<SuccessResult>()))
                .Returns(new Result<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new Result<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new Result<TestCustomServiceResultTypes, TestErrorType>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new Result<TestCustomServiceResultTypes, string[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes>(It.IsAny<SuccessResult>()))
                .Returns(new Result<TestCustomServiceResultTypes>(TestCustomServiceResultTypes.TestValueWithSuccessAttribute));

            MockServiceResultFactory
                .Setup(f => f.Create<TestCustomServiceResultTypes>(It.IsAny<FailureResult>()))
                .Returns(new Result<TestCustomServiceResultTypes>(TestCustomServiceResultTypes.TestValueWithNoAttribute));
        }

        private static void SetupMockDataServiceResultFactory()
        {
            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<ResultTypes>()))
                .Returns(new DataResult<TestData>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<FailureResult>()))
                .Returns(new DataResult<TestData>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<FailureResult>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create<TestData, TestCustomServiceResultTypes, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData>(default, default)); 

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<TestErrorType>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, TestErrorType>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, object[]>(default, default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new DataResult<TestData, TestCustomServiceResultTypes, string[]>(default, default, default));

        }
    }
}
