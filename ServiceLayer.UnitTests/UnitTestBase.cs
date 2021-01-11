using Moq;
using ServiceLayer.Internal;
using ServiceLayer.Internal.Factories;
using ServiceLayer.Internal.Services;
using ServiceLayer.Models;
using Testing.Common.Domain.TestClasses;
using Testing.Common.Infrastructure;

namespace ServiceLayer.UnitTests
{
    public abstract class UnitTestBase : ScenarioUnitTestBase
    {
        internal static readonly Mock<IResultFactory> MockResultFactory = new Mock<IResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IDataResultFactory> MockDataResultFactory = new Mock<IDataResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<ISuccessResultFactory> MockSuccessResultFactory = new Mock<ISuccessResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IFailureResultFactory> MockFailureResultFactory = new Mock<IFailureResultFactory>(MockBehavior.Strict);
        internal static readonly Mock<IResultTypeConversionService> MockResultTypeConversionService = new Mock<IResultTypeConversionService>(MockBehavior.Strict);
        internal static readonly Mock<IInconclusiveResultFactory> MockInconclusiveResultFactory = new Mock<IInconclusiveResultFactory>();

        static UnitTestBase()
        {
            Mock<IServiceLocator> mockServiceLocator = new Mock<IServiceLocator>();
            mockServiceLocator.Setup(l => l.Resolve<IResultTypeConversionService>())
                .Returns(MockResultTypeConversionService.Object);
            mockServiceLocator.Setup(l => l.Resolve<IResultFactory>()).Returns(MockResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IDataResultFactory>()).Returns(MockDataResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<ISuccessResultFactory>()).Returns(MockSuccessResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IFailureResultFactory>()).Returns(MockFailureResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IInconclusiveResultFactory>()).Returns(MockInconclusiveResultFactory.Object);
            ServiceLocator.Instance = mockServiceLocator.Object;

            SetupMockResultTypeConversionService();
            SetupMockResultFactory();
            SetupMockDataResultFactory();
            SetupMockSuccessResultFactory();
            SetupMockFailureResultFactory();
            SetupMockInconclusiveResultFactory();
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
                    s.Convert<ResultType>(TestCustomResultType.TestValueWithNoAttribute))
                .Returns(ResultType.Failure);
            MockResultTypeConversionService.Setup(s =>
                s.Convert<ResultType>(TestCustomResultType.TestValueWithSuccessAttribute))
                .Returns(ResultType.Success);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultType>(TestCustomResultType.TestValueWithFailureAttribute))
                .Returns(ResultType.Failure);
            MockResultTypeConversionService.Setup(s =>
                    s.Convert<ResultType>((TestCustomResultType) 1000))
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
        private static void SetupMockInconclusiveResultFactory()
        {
            MockInconclusiveResultFactory.Setup(f => f.Create())
                .Returns(new InconclusiveResult());
        }

        private static void SetupMockResultFactory()
        {
            MockResultFactory
                .Setup(f => f.Create(It.IsAny<ResultType>()))
                .Returns(new Result(default));
            MockResultFactory
                .Setup(f => f.Create(It.IsAny<ResultType>(), It.IsAny<string[]>()))
                .Returns(new Result<ResultType, string[]>(default, default));

            MockResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomResultType>()))
                .Returns(new Result<TestCustomResultType>(default));

            MockResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomResultType>(), It.IsAny<object[]>()))
                .Returns(new Result<TestCustomResultType, object[]>(default, default));

            MockResultFactory
                .Setup(f => f.Create(It.IsAny<ResultType>(), It.IsAny<object[]>()))
                .Returns(new Result<ResultType, object[]>(default, default));

            MockResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomResultType>(), It.IsAny<TestErrorType>()))
                .Returns(new Result<TestCustomResultType, TestErrorType>(default, default));

            MockResultFactory
                .Setup(f => f.Create<TestCustomResultType, TestErrorType>(It.IsAny<SuccessResult>()))
                .Returns(new Result<TestCustomResultType, TestErrorType>(default, default));

            MockResultFactory
                .Setup(f => f.Create<TestCustomResultType, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new Result<TestCustomResultType, TestErrorType>(default, default));

            MockResultFactory
                .Setup(f => f.Create<TestCustomResultType, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new Result<TestCustomResultType, TestErrorType>(default, default));

            MockResultFactory
                .Setup(f => f.Create(It.IsAny<TestCustomResultType>(), It.IsAny<string[]>()))
                .Returns(new Result<TestCustomResultType, string[]>(default, default));

            MockResultFactory
                .Setup(f => f.Create<TestCustomResultType>(It.IsAny<SuccessResult>()))
                .Returns(new Result<TestCustomResultType>(TestCustomResultType.TestValueWithSuccessAttribute));

            MockResultFactory
                .Setup(f => f.Create<TestCustomResultType>(It.IsAny<FailureResult>()))
                .Returns(new Result<TestCustomResultType>(TestCustomResultType.TestValueWithNoAttribute));
        }

        private static void SetupMockDataResultFactory()
        {
            MockDataResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<ResultType>()))
                .Returns(new DataResult<TestData>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData>(It.IsAny<FailureResult>()))
                .Returns(new DataResult<TestData>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType>(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData, TestCustomResultType>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType>(It.IsAny<FailureResult>()))
                .Returns(new DataResult<TestData, TestCustomResultType>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType>(It.IsAny<TestCustomResultType>()))
                .Returns(new DataResult<TestData, TestCustomResultType>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataResult<TestData, TestCustomResultType>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType, TestErrorType>(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType, TestErrorType>(It.IsAny<TestCustomResultType>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType, TestErrorType>(It.IsAny<TestErrorType>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType, TestErrorType>(It.IsAny<SuccessResult<TestData>>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create<TestData, TestCustomResultType, TestErrorType>(It.IsAny<FailureResult<TestErrorType>>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>()))
                .Returns(new DataResult<TestData>(default, default)); 

            MockDataResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomResultType>()))
                .Returns(new DataResult<TestData, TestCustomResultType>(default, default));

            MockDataResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomResultType>(), It.IsAny<TestErrorType>()))
                .Returns(new DataResult<TestData, TestCustomResultType, TestErrorType>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomResultType>(), It.IsAny<object[]>()))
                .Returns(new DataResult<TestData, TestCustomResultType, object[]>(default, default, default));

            MockDataResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomResultType>(), It.IsAny<string[]>()))
                .Returns(new DataResult<TestData, TestCustomResultType, string[]>(default, default, default));

        }
    }
}
