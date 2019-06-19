using ServiceLayer.Models;

namespace ServiceLayer.Internal.Factories
{
    internal class InconclusiveResultFactory : IInconclusiveResultFactory
    {
        public InconclusiveResult Create()
        {
            return new InconclusiveResult();
        }
    }
}
