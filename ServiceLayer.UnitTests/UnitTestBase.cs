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
        internal static readonly Mock<IResultFactory> MockServiceResultFactory = new Mock<IResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IDataResultFactory> MockDataServiceResultFactory = new Mock<IDataResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<ISuccessResultFactory> MockSuccessResultFactory = new Mock<ISuccessResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IFailureResultFactory> MockFailureResultFactory = new Mock<IFailureResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IResultTypeConversionService> MockResultTypeConversionService = new Mock<IResultTypeConversionService>(MockBehavior.Strict);

        static UnitTestBase()
        {
            Mock<IServiceLocator> mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(MockResultTypeConversionService.Object);
            mockServiceLocator.Setup(l => l.Resolve<IResultFactory>()).Returns(MockServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IDataResultFactory>()).Returns(MockDataServiceResultFactory.Object);
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
            MockResultTypeConversionService.Setup(s => s.Convert<ResultType>(ResultType.Success))
                .Returns(ResultType.Success);
            MockResultTypeConversionService.Setup(s => s.Convert<ResultType>(ResultType.Failure))
                .Returns(ResultType.Failure);
            MockResultTypeConversionService.Setup(s => s.Convert<ResultType>(ResultType.Inconclusive))
                .Returns(ResultType.Inconclusive);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultType>(TestCustomServiceResultTypes.TestValueWithNoAttribute))
                .Returns(ResultType.Failure);
            MockResultTypeConversionService.Setup(s =>
                s.Convert<ResultType>(TestCustomServiceResultTypes.TestValueWithSuccessAttribute))
                .Returns(ResultType.Success);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultType>(TestCustomServiceResultTypes.TestValueWithFailureAttribute))
                .Returns(ResultType.Failure);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultType>((TestCustomServiceResultTypes) 1000))
                .Returns(ResultType.Failure);
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
                .Setup(f => f.Create(It.IsAny<ResultType>()))
                .Returns(new Result(default));
            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ResultType>(), It.IsAny<string[]>()))
                .Returns(new Result<ResultType, string[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>()))
                .Returns(new Result<TestCustomServiceResultTypes>(default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<object[]>()))
                .Returns(new Result<TestCustomServiceResultTypes, object[]>(default, default));

            MockServiceResultFactory
                .Setup(f => f.Create(It.IsAny<ResultType>(), It.IsAny<object[]>()))
                .Returns(new Result<ResultType, object[]>(default, default));

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
                .Setup(f => f.Create<TestData>(It.IsAny<ResultType>()))
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
