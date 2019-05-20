namespace Testing.Common.Infrastructure
{
    public abstract class TestBase
    {
        protected abstract void Arrange();

        protected abstract void Act();

        protected virtual void Finally()
        {

        }
    }
}
