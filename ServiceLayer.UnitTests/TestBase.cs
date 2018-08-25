using NUnit.Framework;

namespace ServiceLayer.UnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public abstract class TestBase
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
