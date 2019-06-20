using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IResultTypeConverterCollection
    {
        IReadOnlyCollection<ResultTypeConverter> Installed { get; }
        void Install(ResultTypeConverter resultTypeConverter);
        void Uninstall(ResultTypeConverter resultTypeConverter);
    }
}
