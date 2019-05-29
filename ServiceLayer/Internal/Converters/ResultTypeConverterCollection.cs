using System;
using System.Collections.Generic;
using ServiceLayer.Converters;

namespace ServiceLayer.Internal.Converters
{
    internal class ResultTypeConverterCollection : IResultTypeConverterCollection
    {
        public IReadOnlyCollection<IResultTypeConverter> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResultTypeConverter<TDestinationResultType> Get<TDestinationResultType>() where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }

        public IResultTypeConverter<TSourceResultType, TDestinationResultType> Get<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }

        public void AddOrReplace<TDestinationResultType>(IResultTypeConverter<TDestinationResultType> resultTypeConverter) where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }

        public void AddOrReplace<TSourceResultType, TDestinationResultType>(IResultTypeConverter<TSourceResultType, TDestinationResultType> resultTypeConverter) where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }

        public void Remove<TDestinationResultType>() where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }

        public void Remove<TSourceResultType, TDestinationResultType>() where TSourceResultType : Enum where TDestinationResultType : Enum
        {
            throw new NotImplementedException();
        }
    }
}
