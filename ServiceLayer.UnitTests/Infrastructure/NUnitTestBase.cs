using NUnit.Framework;

namespace ServiceLayer.UnitTests.Infrastructure
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public abstract class NUnitTestBase
    {
        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            Arrange();
            Act();
        }

        protected abstract void Arrange();

        protected abstract void Act();
    }
}
