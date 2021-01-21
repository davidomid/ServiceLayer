using System;
using System.Collections.Generic;
using ServiceLayer.Core.Converters;

namespace ServiceLayer.Core.Internal.Converters
{
    public interface IActionResultConverterCollection
    {
        IReadOnlyDictionary<Type, IActionResultConverter> Installed { get; }
        void Install(Type sourceType, IActionResultConverter actionResultConverter);
        void Uninstall(Type sourceType);
    }
}
