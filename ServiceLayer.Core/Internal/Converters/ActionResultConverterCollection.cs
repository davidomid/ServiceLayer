using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using ServiceLayer.Core.Converters;

namespace ServiceLayer.Core.Internal.Converters
{
    internal class ActionResultConverterCollection : IActionResultConverterCollection
    {
        private readonly DefaultActionResultTypeConverter _defaultActionResultTypeConverter = new DefaultActionResultTypeConverter();

        private readonly Dictionary<Type, IActionResultConverter> _installedActionResultConverters;

        public ActionResultConverterCollection()
        {
            _installedActionResultConverters = new Dictionary<Type, IActionResultConverter>
            {
                { typeof(IResult), _defaultActionResultTypeConverter },
                { typeof(IResult<HttpStatusCode>), _defaultActionResultTypeConverter },
                { typeof(IResult<HttpStatusCode, object>), _defaultActionResultTypeConverter },
                { typeof(IDataResult<object>), _defaultActionResultTypeConverter },
                { typeof(IDataResult<object, HttpStatusCode>), _defaultActionResultTypeConverter },
                { typeof(IDataResult<object, HttpStatusCode, object>), _defaultActionResultTypeConverter }
            };
        }

        public IReadOnlyDictionary<Type, IActionResultConverter> Installed => new ReadOnlyDictionary<Type, IActionResultConverter>(_installedActionResultConverters);

        public void Install(Type sourceType, IActionResultConverter actionResultConverter)
        {
            if (_installedActionResultConverters.TryGetValue(sourceType, out var existingActionResultConverter))
            {
                if (existingActionResultConverter == actionResultConverter)
                {
                    return;
                }

                _installedActionResultConverters.Remove(sourceType);
            }
            _installedActionResultConverters.Add(sourceType, actionResultConverter);
        }

        public void Uninstall(Type sourceType)
        {
            _installedActionResultConverters.Remove(sourceType);
        }
    }
}
