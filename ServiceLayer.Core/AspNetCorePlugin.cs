﻿using ServiceLayer.Core.Internal;
using ServiceLayer.Core.Internal.Converters;

namespace ServiceLayer.Core
{
    public class AspNetCorePlugin : Plugin
    {
        private readonly ResultTypeConverter[] _resultTypeConverters = 
        {
            new HttpStatusCodeToResultTypesConverter(),
            new ResultTypesToHttpStatusCodeConverter()
        };

        public AspNetCorePlugin(AspNetCorePluginSettings pluginSettings = null) : base("ASP.NET Core")
        {
            if (pluginSettings == null)
            {
                pluginSettings = new AspNetCorePluginSettings();
            }

            ServiceLocator.Instance.Register(pluginSettings);
        }
        
        public override void Install()
        {
            foreach (var resultTypeConverter in _resultTypeConverters)
            {
                Context.ResultTypeConverters.Install(resultTypeConverter);
            }
        }

        public override void Uninstall()
        {
            foreach (var resultTypeConverter in _resultTypeConverters)
            {
                Context.ResultTypeConverters.Uninstall(resultTypeConverter);
            }
        }
    }
}
