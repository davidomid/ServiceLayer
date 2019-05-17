﻿using Moq;
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

            SetupMockServiceResultFactory();
            SetupMockDataServiceResultFactory();
            SetupMockSuccessResultFactory();
            SetupMockFailureResultFactory();

            mockServiceLocator.Setup(l => l.Resolve<IServiceResultFactory>()).Returns(MockServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IDataServiceResultFactory>()).Returns(MockDataServiceResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<ISuccessResultFactory>()).Returns(MockSuccessResultFactory.Object);
            mockServiceLocator.Setup(l => l.Resolve<IFailureResultFactory>()).Returns(MockFailureResultFactory.Object);
            ServiceLocator.Instance = mockServiceLocator.Object;
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
            MockFailureResultFactory.Setup(f => f.Create(It.IsAny<string[]>()))
                .Returns(new FailureResult<string[]>(new []{"test error 1", "test error 2", "test error 3"}));
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
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), default))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes>(default, default));

            MockDataServiceResultFactory
                .Setup(f => f.Create(It.IsAny<TestData>(), It.IsAny<TestCustomServiceResultTypes>(), It.IsAny<string[]>()))
                .Returns(new DataServiceResult<TestData, TestCustomServiceResultTypes, string[]>(default, default, default));
        }
    }
}
