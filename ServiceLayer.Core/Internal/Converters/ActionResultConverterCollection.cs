using System;
using System.Collections.Generic;
using System.Net;
using ServiceLayer.Core.Converters;

namespace ServiceLayer.Core.Internal.Converters
{
    public sealed class ActionResultConverterCollection : Dictionary<Type, IActionResultConverter>
    {
        private static readonly DefaultActionResultConverter DefaultActionResultConverter = new DefaultActionResultConverter();
        private readonly Dictionary<Type, IActionResultConverter> _defaultTypeActionResultConverters = new Dictionary<Type, IActionResultConverter>
        {
            { typeof(IResult), DefaultActionResultConverter },
            { typeof(IResult<HttpStatusCode>), DefaultActionResultConverter },
            { typeof(IResult<HttpStatusCode, object>), DefaultActionResultConverter },
            { typeof(IDataResult<object>), DefaultActionResultConverter },
            { typeof(IDataResult<object, HttpStatusCode>), DefaultActionResultConverter },
            { typeof(IDataResult<object, HttpStatusCode, object>), DefaultActionResultConverter }
        };

        public ActionResultConverterCollection()
        {
            foreach (var defaultTypeActionResultConverter in _defaultTypeActionResultConverters)
            {
                AddIfNotExists(defaultTypeActionResultConverter.Key, defaultTypeActionResultConverter.Value);
            }
        }

        private void AddIfNotExists(Type type, IActionResultConverter actionResultConverter)
        {
            if (!this.ContainsKey(type))
            {
                this.Add(type, actionResultConverter);
            }
        }
    }
}
