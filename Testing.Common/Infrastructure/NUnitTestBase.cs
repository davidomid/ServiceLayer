using NUnit.Framework;

namespace Testing.Common.Infrastructure
{
    [TestFixture]
    public abstract class NUnitTestBase : TestBase
    {
        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            Arrange();
            Act();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            Finally();
        }
    }
}
