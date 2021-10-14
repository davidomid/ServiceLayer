### [ServiceLayer](ServiceLayer.md 'ServiceLayer')
## IPluginContext Interface
This allows you to retrieve and manipulate the plugins and result type converters which are installed by ServiceLayer, from within the installation and uninstallation logic of your custom plugins.  
<remarks>An instance of this interface is available via the <see cref="P:ServiceLayer.Plugin.Context"/> property</remarks>
```csharp
public interface IPluginContext
```

| Properties | |
| :--- | :--- |
| [Plugins](ServiceLayer_IPluginContext_Plugins.md 'ServiceLayer.IPluginContext.Plugins') | Contains a collection of plugins which are currently installed.<br/> |
| [ResultTypeConverters](ServiceLayer_IPluginContext_ResultTypeConverters.md 'ServiceLayer.IPluginContext.ResultTypeConverters') | Contains a collection of result type converters which are currently installed.<br/> |
